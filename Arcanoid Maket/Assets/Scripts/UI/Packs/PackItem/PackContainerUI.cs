using System;
using Library.Localization.UILocalization;
using Library.UI.Button;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Packs.PackItem
{
    public class PackContainerUI : MonoBehaviour
    {
        [SerializeField]
        private EventButton _button;

        [SerializeField]
        private Image _buttonImage;

        [SerializeField]
        private Image _iconImage;

        [SerializeField]
        private TMProCustomTextLocalization _nameText;

        [SerializeField]
        private TMP_Text _levelsText;
        
        [SerializeField]
        private string _levelsFormat = "{0}/{1}";

        private bool _isCallbackSet;
        
        public void SetButtonInteractable(bool isInteractable)
        {
            if (isInteractable)
            {
                _button.Enable();
            }
            else
            {
                _button.Disable();
            }
        }
        
        public void SetButtonColor(Color color)
        {
            _buttonImage.color = color;
        }

        public void SetButtonCallback(Action callback)
        {
            if (!_isCallbackSet)
            {
                _button.OnButtonPressed += callback;
                _isCallbackSet = true;
            }
        }

        public void SetPackIcon(Sprite icon)
        {
            _iconImage.sprite = icon;
        }

        public void SetPackName(string key)
        {
            _nameText.SetTranslationName(key);
        }

        public void SetLevels(int currentLevel, int packsLevelCount)
        {
            _levelsText.text = string.Format(_levelsFormat, currentLevel, packsLevelCount);
        }
    }
}