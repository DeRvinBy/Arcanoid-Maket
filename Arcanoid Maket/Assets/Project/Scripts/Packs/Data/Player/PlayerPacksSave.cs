using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Project.Scripts.Packs.Data.Player
{
    public class PlayerPacksSave
    {
        private const string SaveKey = "PacksSaveJSON";
        private PacksSave _packsSave;

        public void Initialize(string startPackKey)
        {
            LoadPacksSave(startPackKey);
        }

        private void LoadPacksSave(string startPackKey)
        {
            if (PlayerPrefs.HasKey(SaveKey))
            {
                var saveJson = PlayerPrefs.GetString(SaveKey);
                _packsSave = JsonConvert.DeserializeObject<PacksSave>(saveJson);
            }
            else
            {
                CreateDefaultSave(startPackKey);
            }
        }

        private void CreateDefaultSave(string startPackKey)
        {
            _packsSave = new PacksSave {Packs = new Dictionary<string, PackSaveItem>()};
            AddOpenSavePack(startPackKey);
        }
        
        public void AddOpenSavePack(string key)
        {
            var saveItem = new PackSaveItem {IsOpen = true, IsComplete = false, CurrentLevelId = 0};
            _packsSave.Packs.Add(key, saveItem);
        }

        public bool IsPackExist(string key)
        {
            return _packsSave.Packs.ContainsKey(key);
        }
        
        public bool IsPackOpen(string key)
        {
            return _packsSave.Packs[key].IsOpen;
        }
        
        public bool IsPackComplete(string key)
        {
            return _packsSave.Packs[key].IsOpen;
        }
        
        public int GetCurrentLevelId(string key)
        {
            return _packsSave.Packs[key].CurrentLevelId;
        }

        public void CompletePack(string key)
        {
            _packsSave.Packs[key].IsComplete = true;
        }
        
        public void SetCurrentLevelId(string key, int id)
        {
            _packsSave.Packs[key].CurrentLevelId = id;
        }

        public void SavePacksSave()
        {
            var saveJson = JsonConvert.SerializeObject(_packsSave);
            PlayerPrefs.SetString(SaveKey, saveJson);
        }
    }
}