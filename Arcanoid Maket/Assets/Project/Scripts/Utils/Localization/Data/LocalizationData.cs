using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.Utils.Localization.Data
{
    public class LocalizationData
    {
        private const string Path = "Localization/{0}";
        private const string LanguageKey = "language";
        private const string MissingTranslation = "Translation not found!";

        private readonly List<SystemLanguage> _supportedLanguages = new List<SystemLanguage>()
        {
            SystemLanguage.Russian, SystemLanguage.English
        };
        private LocalizationParser _parser;
        private Dictionary<SystemLanguage, Dictionary<string, string>> _translationsMap;
        private SystemLanguage _currentLanguage;

        public void Initialize()
        {
            _parser = new LocalizationParser();
            _translationsMap = new Dictionary<SystemLanguage, Dictionary<string, string>>();
            LoadUserLanguage();
            LoadTranslations();
        }
        
        private void LoadUserLanguage()
        {
            _currentLanguage = SystemLanguage.English;
            
            if (PlayerPrefs.HasKey(LanguageKey))
            {
                var language = PlayerPrefs.GetString(LanguageKey);
                Enum.TryParse(language, out _currentLanguage);
            }
        }

        private void LoadTranslations()
        {
            if (_translationsMap.ContainsKey(_currentLanguage)) return;
            
            var jsonPath = String.Format(Path, _currentLanguage);
            _translationsMap[_currentLanguage] = _parser.GetTranslationsFromJSON(jsonPath);
        }

        public void SaveUserLanguage()
        {
            PlayerPrefs.SetString(LanguageKey, _currentLanguage.ToString());
        }

        public string GetTranslation(string itemName)
        {
            var translations = _translationsMap[_currentLanguage];
            var translation = MissingTranslation;
            if (translations.ContainsKey(itemName))
            {
                translation = translations[itemName];
            }

            return translation;
        }

        public void SetLanguage(SystemLanguage language)
        {
            if (_supportedLanguages.Contains(language))
            {
                _currentLanguage = language;
                LoadTranslations();
            }
            else
            {
                Debug.LogWarning($"[Translation] {language} don't supported.");
            }
        }
    }
}