using System;
using UnityEngine;

namespace Project.Scripts.Utils.Localization.Settings
{
    [Serializable]
    public class TranslationFilesSettings
    {
        [SerializeField]
        private SystemLanguage _language;

        [SerializeField]
        private string translationFileName = "";

        public SystemLanguage Language => _language;

        public string TranslationFileName => translationFileName;
    }
}