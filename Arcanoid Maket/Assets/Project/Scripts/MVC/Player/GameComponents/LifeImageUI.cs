using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.MVC.Player.GameComponents
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