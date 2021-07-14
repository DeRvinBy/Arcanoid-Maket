using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.UI.UIElements
{
    public class SliderPercentTextUI : MonoBehaviour
    {
        private const string PercentTextFormat = "{0:f0}%";
        
        [SerializeField]
        private Slider _slider;
        
        [SerializeField]
        private TMP_Text _sliderText;

        private void Start()
        {
            _slider.onValueChanged.AddListener(OnSliderValueChanged);
            OnSliderValueChanged(_slider.value);
        }

        private void OnDestroy()
        {
            _slider.onValueChanged.RemoveListener(OnSliderValueChanged);
        }

        private void OnSliderValueChanged(float value)
        {
            var percent = (value - _slider.minValue) / (_slider.maxValue - _slider.minValue) * 100;
            _sliderText.text = string.Format(PercentTextFormat, percent);
        }
    }
}