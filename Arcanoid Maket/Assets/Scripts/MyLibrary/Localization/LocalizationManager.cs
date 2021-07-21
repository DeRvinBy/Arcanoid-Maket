using System.Collections.Generic;
using MyLibrary.EventSystem;
using MyLibrary.Localization.Config;
using MyLibrary.Localization.Data;
using MyLibrary.Localization.Interfaces;
using MyLibrary.Singleton;
using UnityEngine;

namespace MyLibrary.Localization
{
    public class LocalizationManager : Singleton<LocalizationManager>
    {
        private const string TranslationsPath = "Data/translations";
        
        private LocalizationData _localization;
        private LocalizationConfig _config;
        
        protected override void Initialize()
        {
            InitializeLocalization();
        }

        private void InitializeLocalization()
        {
            _localization = new LocalizationData();
            _config = Resources.Load<LocalizationConfig>(TranslationsPath);
            _localization.Initialize(_config);
        }

        private void Start()
        {
            EventBus.RaiseEvent<ILanguageChangedEvent>((a) => a.OnLanguageChanged());
        }

        protected override void OnApplicationQuit()
        {
            _localization.SaveUserLanguage();
        }

        public List<SystemLanguage> GetSupportedLanguages()
        {
            return _config.GetSupportedLanguages();
        }

        public SystemLanguage GetCurrentLanguage()
        {
            return _localization.GetCurrentLanguage();
        }
        
        public string GetCurrentTranslation(string itemName)
        {
            return _localization.GetTranslation(itemName);
        }

        public void SetCurrentLanguage(SystemLanguage language)
        {
            _localization.SetLanguage(language);
            EventBus.RaiseEvent<ILanguageChangedEvent>((a) => a.OnLanguageChanged());
        }
    }
}