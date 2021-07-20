using System;
using UnityEngine;

namespace MyLibrary.Localization.Config
{
    [Serializable]
    public class TranslationFilesConfig
    {
        [SerializeField]
        private SystemLanguage _language;

        [SerializeField]
        private TextAsset _translationFile;

        public SystemLanguage Language => _language;
        public TextAsset TranslationFile => _translationFile;
    }
}