using System;
using System.Collections.Generic;
using Scripts.Utils.Localization.Config;
using UnityEngine;

namespace Scripts.Utils.Localization.Data
{
    public class LocalizationData
    {
        private const string LanguageKey = "language";
        private const string MissingTranslation = "Translation not found!";
        
        private LocalizationParser _parser;
        private LocalizationConfig _config;
        private Dictionary<string, string> _translations;
        private SystemLanguage _currentLanguage;

        public void Initialize(LocalizationConfig config)
        {
            _config = config;
            _parser = new LocalizationParser();
            _translations = new Dictionary<string, string>();
            _config.CreateTranslationPathMap();
            LoadUserLanguage();
            LoadTranslations();
        }
        
        private void LoadUserLanguage()
        {
            if (PlayerPrefs.HasKey(LanguageKey))
            {
                var language = PlayerPrefs.GetString(LanguageKey);
                Enum.TryParse(language, out _currentLanguage);
                if (_config.IsLanguageSupported(_currentLanguage))
                {
                    return;
                }
            }
            _currentLanguage = SystemLanguage.English;
        }

        private void LoadTranslations()
        {
            var jsonPath = _config.GetTranslationFile(_currentLanguage);
            _translations = _parser.GetTranslationsFromJSON(jsonPath);
        }

        public void SaveUserLanguage()
        {
            PlayerPrefs.SetString(LanguageKey, _currentLanguage.ToString());
        }

        public string GetTranslation(string itemName)
        {
            var translation = MissingTranslation;
            if (_translations.ContainsKey(itemName))
            {
                translation = _translations[itemName];
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