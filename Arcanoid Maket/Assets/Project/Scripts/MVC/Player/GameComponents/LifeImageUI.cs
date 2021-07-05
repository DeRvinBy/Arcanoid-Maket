using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.MVC.Player.GameComponents
{
    public class LifeImageUI : MonoBehaviour
    {
        [SerializeField]
        private Image icon;
        
        public void ShowLife()
        {
            icon.enabled = true;
        }

        public void HideLife()
        {
            icon.enabled = false;
        }
    }
}