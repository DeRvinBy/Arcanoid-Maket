using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.MVC.FieldBlocks
{
    public class FieldBlocksUI : MonoBehaviour
    {
        [SerializeField]
        private Slider _blocksSlider;

        private int _initialBlockCount;
        
        public void SetupSlider(int blockCount)
        {
            _initialBlockCount = blockCount;
            _blocksSlider.maxValue = _initialBlockCount;
        }

        public void UpdateSlider(int currentBlockCount)
        {
            _blocksSlider.value = _initialBlockCount - currentBlockCount;
        }
    }
}