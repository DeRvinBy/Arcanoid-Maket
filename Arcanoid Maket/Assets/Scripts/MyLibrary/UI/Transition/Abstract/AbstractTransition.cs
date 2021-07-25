using System.Collections;
using MyLibrary.ObjectPool.Abstract;
using UnityEngine;

namespace MyLibrary.UI.Transition.Abstract
{
    public abstract class AbstractTransition : PoolObject
    {
        [SerializeField]
        private AbstractTransitionAnimation _animation;

        public virtual void Initialize()
        {
            if (_animation != null)
            {
                _animation.SetupAnimation();
            }
        }
        
        public IEnumerator ShowForwardTransition()
        {
            gameObject.SetActive(true);
            if (_animation != null)
            {
                yield return _animation.PlayForwardAnimation();
            }
            gameObject.SetActive(false);
        }

        public IEnumerator ShowBackwardTransition()
        {
            gameObject.SetActive(true);
            if (_animation != null)
            {
                yield return _animation.PlayBackwardAnimation();
            }
        }
    }
}