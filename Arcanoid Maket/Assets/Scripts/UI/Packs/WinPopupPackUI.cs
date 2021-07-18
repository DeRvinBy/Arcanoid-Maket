using Scripts.Utils.Localization.UILocalization;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI.Packs
{
    public class WinPopupPackUI : MonoBehaviour
    {
        [SerializeField]
        private Image _packImage;
        
        [SerializeField] 
        private TMProCustomTextLocalization _packText;
        
        [SerializeField]
        private Slider _slider;

        public void SetPackImage(Sprite icon)
        {
            _packImage.sprite = icon;
        }

        public void SetPackName(string packKey)
        {
            _packText.SetTranslationName(packKey);
        }

        public void UpdateSlider(float value, float maxValue)
        {
            _slider.maxValue = maxValue;
            _slider.value = value;
        }
    }
}