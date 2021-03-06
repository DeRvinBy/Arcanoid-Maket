using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MyLibrary.Localization.Config
{
    [CreateAssetMenu(fileName = "New Translation", menuName = "Localization/Translation")]
    public class LocalizationConfig : ScriptableObject
    {
        [SerializeField]
        private TranslationFilesConfig[] _translationFileSettings;
        
        private Dictionary<SystemLanguage, TextAsset> _translationPathMap;

        public void CreateTranslationPathMap()
        {
            _translationPathMap = new Dictionary<SystemLanguage, TextAsset>();
            foreach (var settings in _translationFileSettings)
            {
                _translationPathMap.Add(settings.Language, settings.TranslationFile);
            }
        }

        public TextAsset GetTranslationFile(SystemLanguage language)
        {
            return _translationPathMap[language];
        }

        public List<SystemLanguage> GetSupportedLanguages()
        {
            return _translationPathMap.Keys.ToList();
        }
        
        public bool IsLanguageSupported(SystemLanguage language)
        {
            return _translationPathMap.ContainsKey(language);
        }
    }
}