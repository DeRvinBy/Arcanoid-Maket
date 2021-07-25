using System.Collections;
using MyLibrary.ObjectPool;
using MyLibrary.Singleton;
using MyLibrary.UI.Transition.Abstract;
using MyLibrary.UI.Transition.Components;
using UnityEngine;

namespace MyLibrary.UI.Transition
{
    public class TransitionController : Singleton<TransitionController>
    {
        private AbstractTransition _transition;

        protected override void Initialize()
        {
            var container = PoolsManager.Instance.GetObject<TransitionContainer>(Vector3.zero);
            _transition = container.Transition;
            _transition.Initialize();
        }

        public IEnumerator ShowForwardTransition()
        {
            yield return _transition.ShowForwardTransition();
        }
        
        public IEnumerator ShowBackwardTransition()
        {
            yield return _transition.ShowBackwardTransition();
        }
    }
}