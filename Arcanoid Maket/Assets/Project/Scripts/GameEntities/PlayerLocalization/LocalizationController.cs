using Project.Scripts.BehaviorControllers.Abstract;
using Project.Scripts.Utils.Localization;
using UnityEngine;

namespace Project.Scripts.GameEntities.PlayerLocalization
{
    public class LocalizationController : EntityController
    {
        [SerializeField]
        private LanguageSelectorUI _selector;

        public override void Initialize()
        {
            var languages = LocalizationManager.Instance.GetSupportedLanguages();
            var currentLanguage = LocalizationManager.Instance.GetCurrentLanguage();
            _selector.Initialize(languages, currentLanguage);
            _selector.OnLanguageChanged += OnLanguageChanged;
        }

        private void OnLanguageChanged(SystemLanguage language)
        {
            LocalizationManager.Instance.SetCurrentLanguage(language);
        }
    }
}