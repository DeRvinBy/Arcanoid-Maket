using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.Utils.Localization.Settings
{
    public class LocalizationSettings : MonoBehaviour
    {
        private const string PathFormat = "{0}/{1}";
        
        [SerializeField]
        private string _translationsFolder = null;

        [SerializeField]
        private TranslationFilesSettings[] _translationFileSettings = null;
        
        private Dictionary<SystemLanguage, string> _translationPathMap;

        public void CreateTranslationPathMap()
        {
            _translationPathMap = new Dictionary<SystemLanguage, string>();
            foreach (var settings in _translationFileSettings)
            {
                var path = string.Format(PathFormat, _translationsFolder, settings.TranslationFileName);
                _translationPathMap.Add(settings.Language, path);
            }
        }

        public string GetPathToTranslation(SystemLanguage language)
        {
            return _translationPathMap[language];
        }

        public bool IsLanguageSupported(SystemLanguage language)
        {
            return _translationPathMap.ContainsKey(language);
        }
    }
}