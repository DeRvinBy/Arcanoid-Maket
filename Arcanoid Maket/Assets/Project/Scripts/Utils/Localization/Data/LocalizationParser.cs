using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Project.Scripts.Utils.Localization.Data
{
    public class LocalizationParser
    {
        public Dictionary<string, string> GetTranslationsFromJSON(string path)
        {
            var data = Resources.Load<TextAsset>(path);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(data.text);
        }
    }
}