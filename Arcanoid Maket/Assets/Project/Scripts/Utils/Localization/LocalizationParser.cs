using System.Collections.Generic;
using Project.Scripts.Utils.Localization.Data;
using Project.Scripts.Utils.Localization.Enumerations;
using UnityEngine;

namespace Project.Scripts.Utils.Localization
{
    public class LocalizationParser
    {
        private const string Path = "Localization/localization";
        
        private Translations _translations;
        private Dictionary<LanguageCode, Dictionary<string, string>> _translationsMap;

        public LocalizationParser()
        {
            LoadFromResources();
            CreateTranslationsMap();
        }
        
        private void LoadFromResources()
        {
            var json = Resources.Load<TextAsset>(Path);
            _translations = JsonUtility.FromJson<Translations>(json.text);
        }
        
        private void CreateTranslationsMap()
        {
            _translationsMap = new Dictionary<LanguageCode, Dictionary<string, string>>();
            foreach (var translation in _translations.translations)
            {
                var language = translation.languageCode;
                _translationsMap.Add(language, new Dictionary<string, string>());
                foreach (var item in translation.translationItems)
                {
                    _translationsMap[language].Add(item.name, item.value);
                }
            }
        }
        
        public Dictionary<LanguageCode, Dictionary<string, string>> GetTranslations()
        {
            return _translationsMap;
        }
    }
}