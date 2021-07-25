using System.Collections;
using UnityEngine;

namespace MyLibrary.UI.Transition.Abstract
{
    public abstract class AbstractTransitionAnimation : MonoBehaviour
    {
        public virtual void SetupAnimation() {}
        public abstract IEnumerator PlayBackwardAnimation();
        public abstract IEnumerator PlayForwardAnimation();
    }
}