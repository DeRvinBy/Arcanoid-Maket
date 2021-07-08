using System;
using System.Collections.Generic;
using Project.Scripts.Utils.Localization.Settings;
using UnityEngine;

namespace Project.Scripts.Utils.Localization.Data
{
    public class LocalizationData
    {
        private const string LanguageKey = "language";
        private const string MissingTranslation = "Translation not found!";
        
        private LocalizationParser _parser;
        private LocalizationSettings _settings;
        private Dictionary<SystemLanguage, Dictionary<string, string>> _translationsMap;
        private SystemLanguage _currentLanguage;

        public void Initialize(LocalizationSettings settings)
        {
            _settings = settings;
            _parser = new LocalizationParser();
            _translationsMap = new Dictionary<SystemLanguage, Dictionary<string, string>>();
            _settings.CreateTranslationPathMap();
            LoadUserLanguage();
            LoadTranslations();
        }
        
        private void LoadUserLanguage()
        {
            if (PlayerPrefs.HasKey(LanguageKey))
            {
                var language = PlayerPrefs.GetString(LanguageKey);
                Enum.TryParse(language, out _currentLanguage);
                if (_settings.IsLanguageSupported(_currentLanguage))
                {
                    return;
                }
            }
            
            _currentLanguage = SystemLanguage.English;
        }

        private void LoadTranslations()
        {
            if (_translationsMap.ContainsKey(_currentLanguage)) return;
            
            var jsonPath = _settings.GetPathToTranslation(_currentLanguage);
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
            if (_settings.IsLanguageSupported(language))
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