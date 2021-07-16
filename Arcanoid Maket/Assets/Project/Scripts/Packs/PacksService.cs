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
        private Pack _currentPack;
        private int _currentLevelId;

        public void Initialize(PacksContainer packsContainer)
        {
            _packsMap = packsContainer.GetPacksMap();
            _playerPacksSave = new PlayerPacksSave(new PlayerPrefsLoader());
            _playerPacksSave.LoadPacksSave(packsContainer.FirstPack.Key);
            
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
                packInfo.CurrentLevelInPack = isComplete ? _packsMap[key].LevelCount : _playerPacksSave.GetCurrentLevelId(key) + 1;
                packInfo.IsOpen = _playerPacksSave.IsPackOpen(key);
            }
        }

        public int GetCurrentLevel()
        {
            return _currentLevelId + 1;
        }
        
        public TextAsset GetCurrentLevelFile()
        {
            return _currentPack.GetLevelFileById(_currentLevelId);
        }

        public Pack GetCurrentPack()
        {
            return _currentPack;
        }

        public Dictionary<string, PackInfo> GetPacksInfo()
        {
            return _packsInfoMap;
        }

        public void StartPack(string packKey)
        {
            _currentPack = _packsMap[packKey];
            _currentLevelId = _playerPacksSave.GetCurrentLevelId(packKey);
        }

        public void CompleteLevel()
        {
            _currentLevelId++;
            if (_currentLevelId >= _currentPack.LevelCount)
            {
                _currentLevelId = 0;
                _playerPacksSave.SetCurrentLevelId(_currentPack.Key, _currentLevelId);
                if (!_playerPacksSave.IsPackComplete(_currentPack.Key))
                {
                    _playerPacksSave.CompletePack(_currentPack.Key);
                    UpdatePackInfo(_currentPack.Key);
                }
                SetNextPack();
                if (!_playerPacksSave.IsPackExist(_currentPack.Key))
                {
                    _playerPacksSave.AddOpenSavePack(_currentPack.Key);
                }
            }
            else
            {
                _playerPacksSave.SetCurrentLevelId(_currentPack.Key, _currentLevelId);
            }

            UpdatePackInfo(_currentPack.Key);
        }
        
        private void SetNextPack()
        {
            var keys = _packsMap.Keys.ToArray();
            var currentKeyIndex = Array.IndexOf(keys, _currentPack.Key);
            var currentKey = currentKeyIndex + 1;
            
            if (currentKey < keys.Length)
            {
                _currentPack = _packsMap[keys[currentKey]];
            }
        }
    }
}