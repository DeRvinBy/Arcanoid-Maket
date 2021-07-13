using System.Collections;
using Project.Scripts.Animations.UI;
using UnityEngine;

namespace Project.Scripts.UI.PopupUI.Abstract
{
    public abstract class Popup : MonoBehaviour
    {
        [SerializeField]
        private PopupAnimation _animation;
        
        public virtual void Initialize()
        {
            gameObject.SetActive(false);
            _animation.SetupAnimation();
        }

        public IEnumerator ShowPopup()
        {
            gameObject.SetActive(true);
            yield return _animation.PlayShowAnimation();
            StartPopup();
        }

        public IEnumerator HidePopup()
        {
            yield return _animation.PlayHideAnimation();
            gameObject.SetActive(false);
            ResetPopup();
        }

        protected virtual void StartPopup() {}
        protected virtual void ResetPopup() {}
    }
}