using Project.Scripts.Utils.Localization;
using UnityEngine;

namespace Project.Scripts.GameEntities.PlayerLocalization
{
    public class LocalizationController
    {
        public void Initialize(LanguageSelectorUI selector)
        {
            var languages = LocalizationManager.Instance.GetSupportedLanguages();
            var currentLanguage = LocalizationManager.Instance.GetCurrentLanguage();
            selector.Initialize(languages, currentLanguage);
            selector.OnLanguageChanged += OnLanguageChanged;
        }

        private void OnLanguageChanged(SystemLanguage language)
        {
            LocalizationManager.Instance.SetCurrentLanguage(language);
        }
    }
}