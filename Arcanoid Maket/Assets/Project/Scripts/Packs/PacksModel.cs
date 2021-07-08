using System;
using System.Collections.Generic;
using System.Linq;
using Project.Scripts.Packs.Data.Game;
using Project.Scripts.Packs.Data.Player;
using UnityEngine;

namespace Project.Scripts.Packs
{
    public class PacksModel
    {
        private Dictionary<string, Pack> _packsMap;
        private PlayerPacksSave _playerPacksSave;
        private Pack _currentPack;
        private int _currentLevelId;

        public void Initialize(GamePacks packs)
        {
            _packsMap = packs.GetPacksMap();
            _playerPacksSave = new PlayerPacksSave();
            _playerPacksSave.Initialize(packs.FirstPack.Key);
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
                _playerPacksSave.CompletePack(_currentPack.Key);
                SetNextPack();
                _playerPacksSave.AddOpenSavePack(_currentPack.Key);
            }
            else
            {
                _playerPacksSave.SetCurrentLevelId(_currentPack.Key, _currentLevelId);
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