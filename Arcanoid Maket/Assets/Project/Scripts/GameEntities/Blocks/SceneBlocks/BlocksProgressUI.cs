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
        private BaseAnimationConfig _baseAnimationConfig;

        private ValueAnimation _valueAnimation;
        private int _initialBlockCount;

        public void Initialize()
        {
            _valueAnimation = new ValueAnimation(_baseAnimationConfig.Duration, _baseAnimationConfig.EaseMode);
        }
        
        public void SetupSlider(int blockCount)
        {
            _slider.value = 0;
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