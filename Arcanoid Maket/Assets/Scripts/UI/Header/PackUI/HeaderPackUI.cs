using MyLibrary.Localization.UI;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Header.PackUI
{
    public class HeaderPackUI : MonoBehaviour
    {
        [SerializeField]
        private Image _packImage;

        [SerializeField]
        private TMProValueLocalization _levelText;

        public void SetPackImage(Sprite icon)
        {
            _packImage.sprite = icon;
        }

        public void SetLevelText(string level)
        {
            _levelText.SetValue(level);
        }
    }
}