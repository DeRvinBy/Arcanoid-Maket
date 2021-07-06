using System.Collections;
using Project.Scripts.Animations.UI;
using UnityEngine;

namespace Project.Scripts.UI.PopupUI.Abstract
{
    public abstract class Popup : MonoBehaviour
    {
        [SerializeField]
        private PopupAnimation _animation;
        
        public void Initialize()
        {
            _animation.SetupAnimation();
        }

        public IEnumerator ShowPopup()
        {
            return _animation.PlayShowAnimation();
        }

        public IEnumerator HidePopup()
        {
            return _animation.PlayHideAnimation();
        }

        public abstract void StartPopup();
    }
}