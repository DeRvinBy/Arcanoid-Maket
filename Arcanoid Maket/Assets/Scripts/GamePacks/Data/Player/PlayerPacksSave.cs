using System.Collections.Generic;
using GamePacks.Data.Player.SaveLoadManagers;
using UnityEngine;

namespace GamePacks.Data.Player
{
    public class PlayerPacksSave
    {
        private PacksSaveContainer _packsSaveContainer;
        private readonly IPacksSaveLoadManager _loadManager;
        
        public PlayerPacksSave(IPacksSaveLoadManager loadManager)
        {
            _loadManager = loadManager;
        }
        
        public void SavePacksToSave()
        {
            _loadManager.Save(_packsSaveContainer);
        }
        
        public void LoadPacksFromSave(string startPackKey)
        {
            if (_loadManager.IsSaveExist())
            {
                _packsSaveContainer = _loadManager.Load();
            }
            else
            {
                CreateDefaultSave(startPackKey);             
            }
        }

        private void CreateDefaultSave(string startPackKey)
        {
            _packsSaveContainer = new PacksSaveContainer {Packs = new Dictionary<string, PackSaveItem>()};
            AddOpenSavePack(startPackKey); 
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