using MyLibrary.UI.Transition.Abstract;
using MyLibrary.UI.UIPool;
using UnityEngine;

namespace MyLibrary.UI.Transition.Components
{
    public class TransitionContainer : UIElementPoolObject
    {
        [SerializeField]
        private AbstractTransition _transition;

        public AbstractTransition Transition => _transition;
    }
}