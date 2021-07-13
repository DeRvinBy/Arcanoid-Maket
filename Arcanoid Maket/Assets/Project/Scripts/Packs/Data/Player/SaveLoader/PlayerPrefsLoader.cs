﻿using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Project.Scripts.Packs.Data.Player.SaveLoader
{
    public class PlayerPrefsLoader : ISaveLoader
    {
        private const string SaveKey = "PacksSaveJSON";

        public PacksSaveContainer Load()
        {
            if (!PlayerPrefs.HasKey(SaveKey)) return null;
            
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