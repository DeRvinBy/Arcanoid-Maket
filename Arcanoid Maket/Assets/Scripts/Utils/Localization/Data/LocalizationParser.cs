using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Scripts.Utils.Localization.Data
{
    public class LocalizationParser
    {
        public Dictionary<string, string> GetTranslationsFromJSON(TextAsset data)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(data.text);
        }
    }
}