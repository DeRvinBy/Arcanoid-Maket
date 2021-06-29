using System;
using Project.Scripts.Utils.Localization.Enumerations;

namespace Project.Scripts.Utils.Localization.Data
{
    [Serializable]
    public class TranslationData
    {
        public LanguageCode languageCode;
        public TranslationItem[] translationItems;
    }
}