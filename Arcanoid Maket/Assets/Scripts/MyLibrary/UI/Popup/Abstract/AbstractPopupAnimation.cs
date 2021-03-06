using System.Collections;
using UnityEngine;

namespace MyLibrary.UI.Popup.Abstract
{
    public abstract class AbstractPopupAnimation : MonoBehaviour
    {
        public abstract void SetupAnimation();
        public abstract IEnumerator PlayHideAnimation();
        public abstract IEnumerator PlayShowAnimation();
    }
}