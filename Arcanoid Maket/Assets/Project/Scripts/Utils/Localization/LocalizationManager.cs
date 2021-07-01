using System;
using System.Collections.Generic;
using Project.Scripts.Utils.EventSystem;
using Project.Scripts.Utils.Localization.Enumerations;
using Project.Scripts.Utils.Localization.Interfaces;
using Project.Scripts.Utils.Singleton;
using UnityEngine;

namespace Project.Scripts.Utils.Localization
{
    public class LocalizationManager : Singleton<LocalizationManager>
    {
        private const string LanguageKey = "language";
        private const string WrongTranslationName = "Wrong name!";

        private LocalizationParser _parser;
        private Dictionary<LanguageCode, Dictionary<string, string>> _translations;
        private LanguageCode _currentLanguage;

        protected override void OnAwake()
        {
            LoadTranslations();
            LoadUserLanguage();
        }

        private void Start()
        {
            EventBus.RaiseEvent<ILanguageChangedEvent>((a) => a.OnLanguageChanged());
        }

        private void OnApplicationQuit()
        {
            PlayerPrefs.SetInt(LanguageKey, (int)_currentLanguage);
        }

        private void LoadTranslations()
        {
            _parser = new LocalizationParser();
            _translations = _parser.GetTranslations();
        }

        private void LoadUserLanguage()
        {
            if (PlayerPrefs.HasKey(LanguageKey))
            {
                _currentLanguage = (LanguageCode)PlayerPrefs.GetInt(LanguageKey);
            }
            else
            {
                _currentLanguage = LanguageCode.EN_US;
            }
        }

        public static string GetCurrentTranslation(string itemName)
        {
            return _instance.GetTranslation(itemName);
        }
        
        private string GetTranslation(string itemName)
        {
            var translation = _translations[_currentLanguage];
            if (translation.ContainsKey(itemName))
            {
                return translation[itemName];
            }
            else
            {
                return WrongTranslationName;
            }
        }

        public static void SetCurrentLanguage(int id)
        {
            _instance.SetLanguage(id);
        }
        
        private void SetLanguage(int id)
        {
            var targetID = id % _translations.Count;
            _currentLanguage = (LanguageCode) targetID;
            
            EventBus.RaiseEvent<ILanguageChangedEvent>(a => a.OnLanguageChanged());
        }
    }
}