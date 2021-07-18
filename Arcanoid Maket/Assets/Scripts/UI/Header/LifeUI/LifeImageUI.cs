using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI.Header.LifeUI
{
    public class LifeImageUI : MonoBehaviour
    {
        [SerializeField]
        private Image _icon;
        
        public void ShowLife()
        {
            _icon.enabled = true;
        }

        public void HideLife()
        {
            _icon.enabled = false;
        }
    }
}