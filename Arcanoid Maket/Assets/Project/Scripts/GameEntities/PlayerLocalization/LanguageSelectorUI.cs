using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Project.Scripts.GameEntities.PlayerLocalization
{
    public class LanguageSelectorUI : MonoBehaviour
    {
        public event Action<SystemLanguage> OnLanguageChanged;
        
        [SerializeField]
        private TMP_Dropdown _selector;

        private Dictionary<int, SystemLanguage> _optionsMap;

        private void Awake()
        {
            _selector.onValueChanged.AddListener(OnSelectorValueChanged);
        }

        public void Initialize(List<SystemLanguage> languages, SystemLanguage setupLanguage)
        {
            _optionsMap = new Dictionary<int, SystemLanguage>();
            var optionId = 0;
            var setupId = 0;
            var options = new List<string>();
            foreach (var language in languages)
            {
                var option = language.ToString();
                options.Add(option);
                _optionsMap.Add(optionId, language);
                if (language == setupLanguage)
                {
                    setupId = optionId;
                }
                optionId++;
            }
            _selector.AddOptions(options);
            _selector.value = setupId;
        }

        public void Enable()
        {
            _selector.interactable = true;
        }
        
        public void Disable()
        {
            _selector.interactable = false;
        }
        
        private void OnSelectorValueChanged(int id)
        {
            var language = _optionsMap[id];
            OnLanguageChanged?.Invoke(language);
        }
    }
}