using System;
using System.Collections.Generic;
using System.Linq;
using GamePacks.Data.Packs;
using GamePacks.Data.Player.SaveLoadManagers;
using UnityEngine;

namespace GamePacks.Data.Player
{
    public class PlayerPacks
    {
        private PacksSaveContainer _packsSaveContainer;
        private IPacksSaveLoadManager _saveLoadManager;
        private bool _isSaveExistOnStart;

        public void Initialize(IPacksSaveLoadManager saveLoadManager, Dictionary<string, Pack> packsMap)
        {
            _isSaveExistOnStart = saveLoadManager.IsSaveExist();
            _saveLoadManager = saveLoadManager;
            if (_saveLoadManager.IsSaveExist())
            {
                _packsSaveContainer = _saveLoadManager.LoadSave();
                Debug.Log("Save exist: ");
                foreach (var pack in _packsSaveContainer.Packs)
                {
                    Debug.Log(pack.Key);
                }
                UpdateSaveFirstPack(packsMap);
                UpdateSavePacksByCompleted(packsMap);
            }
            else
            {
                CreateDefaultSave(packsMap);
            }
        }

        private void UpdateSaveFirstPack(Dictionary<string, Pack> packsMap)
        {
            var firstPackKey = packsMap.First().Key;
            if (!IsPackExist(firstPackKey))
            {
                Debug.Log("First pack doesn't exist: " + firstPackKey);
                _isSaveExistOnStart = IsExistOpenPackFromMap(packsMap);
                AddOpenSavePack(firstPackKey);
            }
        }

        private bool IsExistOpenPackFromMap(Dictionary<string, Pack> packsMap)
        {
            var openPacks = _packsSaveContainer.Packs.Where((pack) => pack.Value.IsOpen);
            foreach (var pack in openPacks)
            {
                if (packsMap.ContainsKey(pack.Key))
                {
                    return true;
                }
            }
            return false;
        }

        private void UpdateSavePacksByCompleted(Dictionary<string, Pack> packsMap)
        {
            var completedPlayerPackKeys = _packsSaveContainer.Packs.Where((pack) => pack.Value.IsComplete).
                Select((pair) => pair.Key).ToArray();
            
            var keys = packsMap.Keys.ToArray();
            foreach (var packKey in completedPlayerPackKeys)
            {
                var nextPackIndex = Array.IndexOf(keys, packKey) + 1;
                if (nextPackIndex > 0 && nextPackIndex < keys.Length)
                {
                    var nextPackKey = keys[nextPackIndex];
                    if (!IsPackExist(nextPackKey))
                    {
                        AddOpenSavePack(nextPackKey);
                    }
                }
            }
        }

        private void CreateDefaultSave(Dictionary<string, Pack> packsMap)
        {
            _packsSaveContainer = new PacksSaveContainer {Packs = new Dictionary<string, PackSaveItem>()};
            AddOpenSavePack(packsMap.Keys.First()); 
        }

        public bool IsSaveOnStartExist()
        {
            return _isSaveExistOnStart;
        }

        public void SavePacks()
        {
            Debug.Log("Save: ");
            foreach (var pack in _packsSaveContainer.Packs)
            {
                Debug.Log(pack.Key);
            }
            _saveLoadManager.Save(_packsSaveContainer);
        }
        
        public void AddOpenSavePack(string key)
        {
            if (_packsSaveContainer.Packs.ContainsKey(key)) return;
            
            var saveItem = new PackSaveItem {IsOpen = true, IsComplete = false, CurrentLevelId = 0};
            _packsSaveContainer.Packs.Add(key, saveItem);
        }

        public bool IsPackExist(string key)
        {
            return _packsSaveContainer.Packs.ContainsKey(key);
        }
        
        public bool IsPackOpen(string key)
        {
            return _packsSaveContainer.Packs[key].IsOpen;
        }
        
        public bool IsPackComplete(string key)
        {
            return _packsSaveContainer.Packs[key].IsComplete;
        }

        public int GetCurrentLevelId(string key)
        {
            return _packsSaveContainer.Packs[key].CurrentLevelId;
        }

        public void CompletePack(string key)
        {
            _packsSaveContainer.Packs[key].IsComplete = true;
        }
        
        public void SetCurrentLevelId(string key, int id)
        {
            _packsSaveContainer.Packs[key].CurrentLevelId = id;
        }
    }
}