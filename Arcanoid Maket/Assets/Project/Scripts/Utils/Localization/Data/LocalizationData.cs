using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Project.Scripts.Utils.Localization.Config;
using UnityEngine;

namespace Project.Scripts.Utils.Localization.Data
{
    public class LocalizationData
    {
        private const string LanguageKey = "language";
        private const string MissingTranslation = "Translation not found!";
        
        private LocalizationParser _parser;
        private LocalizationConfig _config;
        private Dictionary<SystemLanguage, Dictionary<string, string>> _translationsMap;
        private SystemLanguage _currentLanguage;

        public void Initialize(LocalizationConfig config)
        {
            _config = config;
            _parser = new LocalizationParser();
            _translationsMap = new Dictionary<SystemLanguage, Dictionary<string, string>>();
            _config.CreateTranslationPathMap();
            LoadUserLanguage();
            LoadTranslations();
        }
        
        private void LoadUserLanguage()
        {
            if (PlayerPrefs.HasKey(LanguageKey))
            {
                Debug.Log("Load Russian");
                var language = PlayerPrefs.GetString(LanguageKey);
                Enum.TryParse(language, out _currentLanguage);
                if (_config.IsLanguageSupported(_currentLanguage))
                {
                    return;
                }
            }
            Debug.Log("Load English");
            _currentLanguage = SystemLanguage.English;
        }

        private void LoadTranslations()
        {
            if (_translationsMap.ContainsKey(_currentLanguage)) return;
            
            var jsonPath = _config.GetTranslationFile(_currentLanguage);
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

        public SystemLanguage GetCurrentLanguage()
        {
            return _currentLanguage;
        }
        
        public void SetLanguage(SystemLanguage language)
        {
            if (_config.IsLanguageSupported(language))
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