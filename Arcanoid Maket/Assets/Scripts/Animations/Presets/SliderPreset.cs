using System;
using Animations.Configs;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Animations.Presets
{
    [Serializable]
    public class SliderPreset
    {
        [SerializeField]
        private BaseAnimationConfig _baseConfig;

        [SerializeField]
        private Slider _slider;

        private ValueAnimation _valueAnimation;

        public Tween GetAnimationTween(float from, float to)
        {
            if (_valueAnimation == null)
            {
                _valueAnimation = new ValueAnimation(_baseConfig.EaseMode, _baseConfig.Duration);
            }

            var tween = _valueAnimation.GetAnimation(from, to, UpdateSliderValue);
            return tween;
        }
        
        private void UpdateSliderValue(float value)
        {
            _slider.value = value;
        }
    }
}