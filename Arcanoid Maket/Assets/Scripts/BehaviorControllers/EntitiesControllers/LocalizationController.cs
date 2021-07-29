using MyLibrary.Localization;
using UI.Menu;
using UnityEngine;

namespace BehaviorControllers.EntitiesControllers
{
    public class LocalizationController
    {
        public void Initialize(LanguageSelectorUI selector)
        {
            var languages = LocalizationManager.Instance.GetSupportedLanguages();
            var currentLanguage = LocalizationManager.Instance.GetCurrentLanguage();
            selector.Initialize(languages, currentLanguage);
            selector.OnUserChangeLanguage += ChangeLanguage;
        }

        private void ChangeLanguage(SystemLanguage language)
        {
            LocalizationManager.Instance.SetCurrentLanguage(language);
        }
    }
}