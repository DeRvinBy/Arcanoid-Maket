using Library.Localization;
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
            selector.OnUserChangeLanguage += DOOnUserChangeUserLanguage;
        }

        private void DOOnUserChangeUserLanguage(SystemLanguage language)
        {
            LocalizationManager.Instance.SetCurrentLanguage(language);
        }
    }
}