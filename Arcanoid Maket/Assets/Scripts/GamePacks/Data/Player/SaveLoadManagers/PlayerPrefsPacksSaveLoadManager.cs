using Newtonsoft.Json;
using UnityEngine;

namespace GamePacks.Data.Player.SaveLoadManagers
{
    public class PlayerPrefsPacksSaveLoadManager : IPacksSaveLoadManager
    {
        private const string SaveKey = "PacksSaveJSON";
        
        private PacksSaveContainer _saveContainer;
        private string _packsContainerKey;

        public PlayerPrefsPacksSaveLoadManager(string packsContainerKey)
        {
            _packsContainerKey = packsContainerKey;
            if (!PlayerPrefs.HasKey(SaveKey)) return;
            LoadSave();
        }

        private void LoadSave()
        {
            var saveJson = PlayerPrefs.GetString(SaveKey);
            var saveContainer = JsonConvert.DeserializeObject<PacksSaveContainer>(saveJson);

            if (saveContainer.PackContainerKey == _packsContainerKey)
            {
                _saveContainer = saveContainer;
            }
            else
            {
                PlayerPrefs.DeleteKey(SaveKey);
            }
        }

        public bool IsSaveExist()
        {
            return PlayerPrefs.HasKey(SaveKey);
        }

        public PacksSaveContainer GetSave()
        {
            return _saveContainer;
        }

        public void Save(PacksSaveContainer container)
        {
            container.PackContainerKey = _packsContainerKey;
            var saveJson = JsonConvert.SerializeObject(container);
            PlayerPrefs.SetString(SaveKey, saveJson);
        }
    }
}