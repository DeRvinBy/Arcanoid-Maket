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
        }

        public IEnumerator HidePopup()
        {
            yield return _animation.PlayHideAnimation();
            gameObject.SetActive(false);
        }

        public abstract void StartPopup();
    }
}