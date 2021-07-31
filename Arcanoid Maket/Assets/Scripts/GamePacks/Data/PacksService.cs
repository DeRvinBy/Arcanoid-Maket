using System;
using System.Collections.Generic;
using System.Linq;
using GamePacks.Data.Config;
using GamePacks.Data.Packs;
using GamePacks.Data.Player;
using UnityEngine;

namespace GamePacks.Data
{
    public class PacksService
    {
        private Dictionary<string, Pack> _packsMap;
        private Dictionary<string, PackInfo> _packsInfoMap;
        private PlayerPacks _playerPacks;
        private string _currentPackKey;
        private int _currentLevelId;

        public void Initialize(PlayerPacks playerPacks, PacksConfig packsConfig)
        {
            _playerPacks = playerPacks;
            _packsMap = packsConfig.GetPacksMap();
            CreateInfoMap();
        }

        private void CreateInfoMap()
        {
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
                _playerPacks.AddOpenSavePack(key);
                _playerPacks.CompletePack(key);
            }
        }

        private void UpdatePackInfo(string key)
        {
            var packInfo = _packsInfoMap[key];
            packInfo.GamePack = _packsMap[key];
            
            if (_playerPacks.IsPackExist(key))
            {
                var isComplete = _playerPacks.IsPackComplete(key);
                var currentLevel = _playerPacks.GetCurrentLevelId(key);
                var packsLevelCount = _packsMap[key].LevelCount;
                packInfo.CurrentLevel = currentLevel + 1;
                packInfo.PackProgressLevel = isComplete ? packsLevelCount : currentLevel;
                packInfo.IsOpen = _playerPacks.IsPackOpen(key);
            }
        }

        public TextAsset GetCurrentLevelFile()
        {
            return _packsMap[_currentPackKey].GetLevelFileById(_currentLevelId);
        }

        public PackInfo GetCurrentPackInfo()
        {
            if (string.IsNullOrEmpty(_currentPackKey)) return null;
            return _packsInfoMap[_currentPackKey];
        }

        public Dictionary<string, PackInfo> GetPacksInfo()
        {
            return _packsInfoMap;
        }

        public void StartPack(string packKey)
        {
            _currentPackKey = packKey;
            _currentLevelId = _playerPacks.GetCurrentLevelId(packKey);
        }
        
        public void StartDebugPack(string packKey, int currentLevel)
        {
            _playerPacks.AddOpenSavePack(packKey);
            _currentPackKey = packKey;
            _currentLevelId = currentLevel;
        }

        public void CompleteLevel()
        {
            _currentLevelId++;
            if (_currentLevelId >= _packsMap[_currentPackKey].LevelCount)
            {
                _currentLevelId = 0;
                _playerPacks.SetCurrentLevelId(_currentPackKey, _currentLevelId);
                if (!_playerPacks.IsPackComplete(_currentPackKey))
                {
                    _playerPacks.CompletePack(_currentPackKey);
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
                _playerPacks.SetCurrentLevelId(_currentPackKey, _currentLevelId);
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
                _playerPacks.AddOpenSavePack(_currentPackKey);
            }
            else
            {
                _packsInfoMap[_currentPackKey].IsLastPack = true;
            }
        }
    }
}