using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Project.Scripts.BehaviorControllers.Abstract;
using Project.Scripts.UI.PopupUI.Abstract;
using UnityEngine;

namespace Project.Scripts.UI.PopupUI
{
    public class PopupsController : EntityController
    {
        [SerializeField]
        private AbstractPopup[] _popups;

        private Stack<AbstractPopup> _popupsStack;

        private bool _isAnimate;
        
        public override void Initialize()
        {
            _popupsStack = new Stack<AbstractPopup>();
            foreach (var popup in _popups)
            {
                popup.Initialize();
            }
        }

        public IEnumerator ShowPopup<T>() where T : AbstractPopup
        {
            var popup = _popups.First(p => p is T);
            _popupsStack.Push(popup);
            yield return popup.ShowPopup();
        }

        public IEnumerator PushPopup<T>() where T : AbstractPopup
        {
            yield return HideLastPopup();
            yield return ShowPopup<T>();
        }

        public IEnumerator HideLastPopup()
        {
            var popup = _popupsStack.Pop();
            yield return popup.HidePopup();
        }

        public IEnumerator HideAllActivePopups()
        {
            //print("hide");
            for (int i = 0; i < _popupsStack.Count; i++)
            {
                var popup = _popupsStack.Pop();
                yield return popup.HidePopup();
            }
            _popupsStack.Clear();
        }
    }
}