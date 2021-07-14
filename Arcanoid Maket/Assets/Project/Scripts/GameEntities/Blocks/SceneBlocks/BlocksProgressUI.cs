using System;
using Project.Scripts.Animations;
using Project.Scripts.Animations.Configs;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.GameEntities.Blocks.SceneBlocks
{
    public class BlocksProgressUI : MonoBehaviour
    {
        [SerializeField]
        private Slider _slider;

        [SerializeField]
        private BaseAnimationConfig _baseConfig;

        private ValueAnimation _valueAnimation;
        private int _initialBlockCount;

        public void Initialize()
        {
            _valueAnimation = new ValueAnimation(_baseConfig.EaseMode, _baseConfig.Duration);
        }

        public void ResetSlider()
        {
            _slider.value = 0;
            _valueAnimation.KillAnimation();
        }

        public void SetupSlider(int blockCount)
        {
            _initialBlockCount = blockCount;
            _slider.maxValue = _initialBlockCount;
        }

        public void UpdateSlider(int currentBlockCount)
        {
            var fromValue = _slider.value;
            var toValue = _initialBlockCount - currentBlockCount;
            _valueAnimation.PlayAnimation(fromValue, toValue, UpdateSliderValue);
        }

        private void UpdateSliderValue(float value)
        {
            _slider.value = value;
        }
    }
}