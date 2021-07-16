using System;
using System.Collections.Generic;
using System.Linq;
using Project.Scripts.Packs.Data.Packs;
using Project.Scripts.Packs.Data.Player;
using Project.Scripts.Packs.Data.Player.SaveLoader;
using UnityEngine;

namespace Project.Scripts.Packs
{
    public class PacksService
    {
        private Dictionary<string, Pack> _packsMap;
        private Dictionary<string, PackInfo> _packsInfoMap;
        private PlayerPacksSave _playerPacksSave;
        private string _currentPackKey;
        private int _currentLevelId;

        public void Initialize(PacksContainer packsContainer)
        {
            _packsMap = packsContainer.GetPacksMap();
            _playerPacksSave = new PlayerPacksSave(new PlayerPrefsLoader());
            _playerPacksSave.LoadPacksFromSave(packsContainer.FirstPack.Key);
            
            _packsInfoMap = new Dictionary<string, PackInfo>();
            foreach (var packKey in _packsMap.Keys)
            {
                var packInfo = new PackInfo();
                _packsInfoMap.Add(packKey, packInfo);
                UpdatePackInfo(packKey);
            }
        }

        private void UpdatePackInfo(string key)
        {
            var packInfo = _packsInfoMap[key];
            packInfo.GamePack = _packsMap[key];
            
            if (_playerPacksSave.IsPackExist(key))
            {
                var isComplete = _playerPacksSave.IsPackComplete(key);
                var currentLevel = _playerPacksSave.GetCurrentLevelId(key);
                var packsLevelCount = _packsMap[key].LevelCount;
                packInfo.IsComplete = isComplete;
                packInfo.CurrentLevel = currentLevel + 1;
                packInfo.PackProgressLevel = isComplete ? packsLevelCount : currentLevel;
                packInfo.IsOpen = _playerPacksSave.IsPackOpen(key);
            }
        }

        public TextAsset GetCurrentLevelFile()
        {
            return _packsMap[_currentPackKey].GetLevelFileById(_currentLevelId);
        }

        public PackInfo GetCurrentPackInfo()
        {
            return _packsInfoMap[_currentPackKey];
        }

        public Dictionary<string, PackInfo> GetPacksInfo()
        {
            return _packsInfoMap;
        }

        public void StartPack(string packKey)
        {
            _currentPackKey = packKey;
            _currentLevelId = _playerPacksSave.GetCurrentLevelId(packKey);
        }

        public void CompleteLevel()
        {
            _currentLevelId++;
            if (_currentLevelId >= _packsMap[_currentPackKey].LevelCount)
            {
                _currentLevelId = 0;
                _playerPacksSave.SetCurrentLevelId(_currentPackKey, _currentLevelId);
                if (!_playerPacksSave.IsPackComplete(_currentPackKey))
                {
                    _playerPacksSave.CompletePack(_currentPackKey);
                    UpdatePackInfo(_currentPackKey);
                    SetNextPack();
                }
                else
                {
                    _packsInfoMap[_currentPackKey].IsPackReplayed = true;
                }
            }
            else
            {
                _playerPacksSave.SetCurrentLevelId(_currentPackKey, _currentLevelId);
                _packsInfoMap[_currentPackKey].IsPackReplayed = false;
            }

            UpdatePackInfo(_currentPackKey);
        }
        
        private void SetNextPack()
        {
            var keys = _packsMap.Keys.ToArray();
            var currentKeyIndex = Array.IndexOf(keys, _currentPackKey);
            var currentKey = currentKeyIndex + 1;
            
            if (currentKey < keys.Length)
            {
                _currentPackKey = keys[currentKey];
                _playerPacksSave.AddOpenSavePack(_currentPackKey);
            }
            else
            {
                _packsInfoMap[_currentPackKey].IsLastPack = true;
            }
        }

        public void SavePlayerPacks()
        {
            _playerPacksSave.SavePacksToSave();
        }
    }
}