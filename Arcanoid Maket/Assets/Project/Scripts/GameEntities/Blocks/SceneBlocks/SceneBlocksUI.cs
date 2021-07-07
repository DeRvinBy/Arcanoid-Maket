using Project.Scripts.Animations;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.GameEntities.Blocks.SceneBlocks
{
    public class SceneBlocksUI : MonoBehaviour
    {
        [SerializeField]
        private Slider _blocksSlider;

        [SerializeField]
        private ValueAnimation _valueAnimation;
        
        private int _initialBlockCount;
        
        public void SetupSlider(int blockCount)
        {
            _initialBlockCount = blockCount;
            _blocksSlider.maxValue = _initialBlockCount;
        }

        public void UpdateSlider(int currentBlockCount)
        {
            var fromValue = _blocksSlider.value;
            var toValue = _initialBlockCount - currentBlockCount;
            _valueAnimation.PlayAnimation(fromValue, toValue, UpdateSliderValue);
        }

        private void UpdateSliderValue(float value)
        {
            _blocksSlider.value = value;
        }
    }
}