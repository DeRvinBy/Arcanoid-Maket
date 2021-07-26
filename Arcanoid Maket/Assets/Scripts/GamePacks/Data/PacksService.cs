using System;
using System.Collections.Generic;
using System.Linq;
using GamePacks.Data.Packs;
using GamePacks.Data.Player;
using GamePacks.Data.Player.SaveLoader;
using UnityEngine;

namespace GamePacks.Data
{
    public class PacksService
    {
        private Dictionary<string, Pack> _packsMap;
        private Dictionary<string, PackInfo> _packsInfoMap;
        private PlayerPacksSave _playerPacksSave;
        private string _currentPackKey;
        private int _currentLevelId;
        private bool _isSaveExist;

        public void Initialize(PacksConfig packsConfig)
        {
            _packsMap = packsConfig.GetPacksMap();
            var loader = new PlayerPrefsLoader();
            _isSaveExist = loader.IsSaveExist();
            _playerPacksSave = new PlayerPacksSave(loader);
            var firstPack = packsConfig.FirstPack.Key;
            _playerPacksSave.LoadPacksFromSave(firstPack);
            if (!_isSaveExist)
            {
                StartPack(firstPack);
            }

            _packsInfoMap = new Dictionary<string, PackInfo>();
            foreach (var packKey in _packsMap.Keys)
            {
                var packInfo = new PackInfo();
                _packsInfoMap.Add(packKey, packInfo);
                UpdatePackInfo(packKey);
            }
        }

        public void CompleteAllPacks()
        {
            foreach (var key in _packsMap.Keys)
            {
                _playerPacksSave.AddOpenSavePack(key);
                _playerPacksSave.CompletePack(key);
            }
        }

        public bool IsSaveExit()
        {
            return _isSaveExist;
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
        
        public void StartDebugPack(string packKey, int currentLevel)
        {
            _playerPacksSave.AddOpenSavePack(packKey);
            _currentPackKey = packKey;
            _currentLevelId = currentLevel;
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