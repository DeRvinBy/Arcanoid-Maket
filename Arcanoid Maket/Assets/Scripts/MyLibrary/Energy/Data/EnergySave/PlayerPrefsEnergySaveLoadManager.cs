using System;
using MyLibrary.Energy.Data.EnergySave.Interfaces;
using Newtonsoft.Json;
using UnityEngine;

namespace MyLibrary.Energy.Data.EnergySave
{
    public class PlayerPrefsEnergySaveLoadManager : IEnergySaveLoadManager
    {
        private const string SaveKey = "EnergySave";
        
        public bool IsSaveExist()
        {
            return PlayerPrefs.HasKey(SaveKey);
        }

        public EnergySaveItem LoadEnergySave()
        {
            if (IsSaveExist())
            {
                var json = PlayerPrefs.GetString(SaveKey);
                return JsonConvert.DeserializeObject<EnergySaveItem>(json);
            }

            var save = new EnergySaveItem {TimeSaveValue = DateTime.Now};
            return save;
        }

        public void SaveEnergySave(EnergySaveItem save)
        {
            var json = JsonConvert.SerializeObject(save);
            PlayerPrefs.SetString(SaveKey, json);
        }
    }
}