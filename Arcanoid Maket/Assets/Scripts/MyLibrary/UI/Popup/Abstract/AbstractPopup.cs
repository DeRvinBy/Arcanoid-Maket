using System;
using System.Collections;
using MyLibrary.UI.UIPool;
using UnityEngine;

namespace MyLibrary.UI.Popup.Abstract
{
    public abstract class AbstractPopup : UIElementPoolObject
    {
        [SerializeField]
        private AbstractPopupAnimation _popupAnimation;

        public override void Initialize()
        {
            gameObject.SetActive(false);
            if (_popupAnimation != null)
            {
                _popupAnimation.SetupAnimation();
            }
        }

        public IEnumerator ShowPopup(Action onComplete)
        {
            gameObject.SetActive(true);
            PreparePopup();
            if (_popupAnimation != null)
            {
                yield return _popupAnimation.PlayShowAnimation();
            }
            
            StartPopup(onComplete);
        }

        public IEnumerator HidePopup()
        {
            if (_popupAnimation != null)
            {
                yield return _popupAnimation.PlayHideAnimation();
            }
            ResetPopup();
            gameObject.SetActive(false);
        }
        
        protected virtual void PreparePopup() {}
        protected virtual void StartPopup(Action onComplete) {}
        protected virtual void ResetPopup() {}
    }
}