using Scripts.UI.Menu;
using Scripts.Utils.Localization;
using UnityEngine;

namespace Scripts.BehaviorControllers.EntitiesControllers
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