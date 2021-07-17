using System.Collections;
using Project.Scripts.Utils.ObjectPool.Abstract;
using UnityEngine;

namespace Project.Scripts.Utils.UI.Popup.Abstract
{
    public abstract class AbstractPopup : PoolObject
    {
        [SerializeField]
        private AbstractPopupAnimation _popupAnimation;
        
        public virtual void Initialize()
        {
            gameObject.SetActive(false);
            if (_popupAnimation != null)
            {
                _popupAnimation.SetupAnimation();
            }
        }

        public IEnumerator ShowPopup()
        {
            gameObject.SetActive(true);
            if (_popupAnimation != null)
            {
                yield return _popupAnimation.PlayShowAnimation();
            }
            
            StartPopup();
        }

        public IEnumerator HidePopup()
        {
            ResetPopup();
            if (_popupAnimation != null)
            {
                yield return _popupAnimation.PlayHideAnimation();
            }
            gameObject.SetActive(false);
        }

        protected virtual void StartPopup() {}
        protected virtual void ResetPopup() {}
    }
}