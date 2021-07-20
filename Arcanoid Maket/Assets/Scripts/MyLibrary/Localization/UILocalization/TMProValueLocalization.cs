using System;
using UnityEngine;

namespace MyLibrary.Localization.UILocalization
{
    public class TMProValueLocalization : TMProTextLocalization
    {
        [SerializeField]
        private string _textWithValueFormat = "{0}: {1}";
        
        private string _value;

        public void SetValue(string value)
        {
            _value = value;
            OnLanguageChanged();
        }
        
        public override void OnLanguageChanged()
        {
            var translation = LocalizationManager.Instance.GetCurrentTranslation(_translationName);
            _tmpText.text = String.Format(_textWithValueFormat, translation, _value);
        }
    }
}