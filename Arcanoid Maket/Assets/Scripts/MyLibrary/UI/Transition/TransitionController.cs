using System.Collections.Generic;
using MyLibrary.Singleton;
using MyLibrary.UI.Transition.Abstract;
using UnityEngine;

namespace MyLibrary.UI.Transition
{
    public class TransitionController : Singleton<TransitionController>
    {
        [SerializeField]
        private Transform _transitionParent;

        [SerializeField]
        private AbstractTransition _transition;
    }
}