using System.Collections.Generic;
using Project.Scripts.Packs.Data.Player.SaveLoader;

namespace Project.Scripts.Packs.Data.Player
{
    public class PlayerPacksSave
    {
        private PacksSaveContainer _packsSaveContainer;
        private readonly ISaveLoader _loader;
        
        public PlayerPacksSave(ISaveLoader loader)
        {
            _loader = loader;
        }
        
        public void SavePacksSave()
        {
            _loader.Save(_packsSaveContainer);
        }
        
        public void LoadPacksSave(string startPackKey)
        {
            _packsSaveContainer = _loader.Load();
            if (_packsSaveContainer == null)
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
            return _packsSaveContainer.Packs[key].IsOpen;
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