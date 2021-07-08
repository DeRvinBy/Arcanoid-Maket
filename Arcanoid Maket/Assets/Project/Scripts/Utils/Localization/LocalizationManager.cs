using Project.Scripts.Utils.EventSystem;
using Project.Scripts.Utils.Localization.Data;
using Project.Scripts.Utils.Localization.Interfaces;
using Project.Scripts.Utils.Localization.Settings;
using Project.Scripts.Utils.Singleton;
using UnityEngine;

namespace Project.Scripts.Utils.Localization
{
    public class LocalizationManager : Singleton<LocalizationManager>
    {
        [SerializeField]
        private LocalizationSettings _settings = null;
        
        private LocalizationData _localization;
        
        protected override void Awake()
        {
            base.Awake();
            _localization = new LocalizationData();
            _localization.Initialize(_settings);
        }

        private void Start()
        {
            EventBus.RaiseEvent<ILanguageChangedEvent>((a) => a.OnLanguageChanged());
        }

        private void OnApplicationQuit()
        {
            _localization.SaveUserLanguage();
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