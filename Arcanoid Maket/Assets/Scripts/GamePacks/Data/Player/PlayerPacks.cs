using System;
using System.Collections.Generic;
using System.Linq;
using GamePacks.Data.Packs;
using GamePacks.Data.Player.SaveLoadManagers;

namespace GamePacks.Data.Player
{
    public class PlayerPacks
    {
        private PacksSaveContainer _packsSaveContainer;
        private IPacksSaveLoadManager _loadManager;

        public void Initialize(IPacksSaveLoadManager loadManager, Dictionary<string, Pack> packsMap)
        {
            _loadManager = loadManager;
            if (_loadManager.IsSaveExist())
            {
                _packsSaveContainer = _loadManager.GetSave();
                UpdateSave(packsMap);
            }
            else
            {
                CreateDefaultSave(packsMap);             
            }
        }

        private void UpdateSave(Dictionary<string, Pack> packsMap)
        {
            var lastCompletedPlayerPackKey = _packsSaveContainer.Packs.LastOrDefault((pair) => pair.Value.IsComplete).Key;

            if (string.IsNullOrEmpty(lastCompletedPlayerPackKey)) return;
            
            var keys = packsMap.Keys.ToArray();
            var nextPackIndex = Array.IndexOf(keys, lastCompletedPlayerPackKey) + 1;
            if (nextPackIndex < keys.Length)
            {
                var nextPackKey = keys[nextPackIndex];
                AddOpenSavePack(nextPackKey);
            }
        }

        private void CreateDefaultSave(Dictionary<string, Pack> packsMap)
        {
            _packsSaveContainer = new PacksSaveContainer {Packs = new Dictionary<string, PackSaveItem>()};
            AddOpenSavePack(packsMap.Keys.First()); 
        }

        public void SavePacks()
        {
            _loadManager.Save(_packsSaveContainer);
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