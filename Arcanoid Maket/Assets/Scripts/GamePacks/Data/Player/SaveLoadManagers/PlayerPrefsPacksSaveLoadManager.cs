using GamePacks.Data.Player.Data;
using Newtonsoft.Json;
using UnityEngine;

namespace GamePacks.Data.Player.SaveLoadManagers
{
    public class PlayerPrefsPacksSaveLoadManager : IPacksSaveLoadManager
    {
        private const string SaveKey = "PacksSaveJSON";

        public PlayerPrefsPacksSaveLoadManager()
        {
            if (!PlayerPrefs.HasKey(SaveKey)) return;
            LoadSave();
        }

        public bool IsSaveExist()
        {
            return PlayerPrefs.HasKey(SaveKey);
        }

        public PacksSaveContainer LoadSave()
        {
            var saveJson = PlayerPrefs.GetString(SaveKey);
            var saveContainer = JsonConvert.DeserializeObject<PacksSaveContainer>(saveJson);
            return saveContainer;
        }

        public void Save(PacksSaveContainer container)
        {
            var saveJson = JsonConvert.SerializeObject(container);
            PlayerPrefs.SetString(SaveKey, saveJson);
        }
    }
}