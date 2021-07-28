using System;
using Animations.Presets;
using DG.Tweening;
using MyLibrary.Localization.UI;
using MyLibrary.UI.Button;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Packs
{
    public class WinPopupPackUI : MonoBehaviour
    {
        [SerializeField]
        private Image _packImage;
        
        [SerializeField] 
        private TMProCustomTextLocalization _packText;
        
        [SerializeField]
        private Slider _slider;
        
        [SerializeField]
        private SliderPreset _sliderAnimation;

        [SerializeField]
        private EventButton _nextButton;
        
        [SerializeField]
        private CanvasGroupPreset _buttonAnimation;
        
        private float _previousSliderValue;
        
        public void SetPackImage(Sprite icon)
        {
            _packImage.sprite = icon;
        }

        public void SetPackName(string packKey)
        {
            _packText.SetTranslationName(packKey);
        }

        public void SetupSlider(float currentValue, float maxValue)
        {
            _previousSliderValue = currentValue;
            _slider.maxValue = maxValue;
            _slider.value = currentValue;
        }

        public void PreaprePackUI()
        {
            _buttonAnimation.ResetToStartAlpha();
            _nextButton.Disable();
        }
        
        public void UpdatePackProgress(float nextSliderValue, TweenCallback onPackChanged)
        {
            var animationSequence = DOTween.Sequence();

            var sliderTween = _sliderAnimation.GetAnimationTween(_previousSliderValue, nextSliderValue);
            sliderTween.onComplete += onPackChanged;
            _previousSliderValue = nextSliderValue;
            animationSequence.Append(sliderTween);

            var buttonTween = _buttonAnimation.GetForwardAnimation();
            buttonTween.onComplete += _nextButton.Enable;
            animationSequence.Append(buttonTween);
        }
    }
}