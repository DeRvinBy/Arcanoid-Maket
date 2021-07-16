using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.GameEntities.Player.Components
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