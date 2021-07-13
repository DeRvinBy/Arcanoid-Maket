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
        private Popup[] _popups;

        private Stack<Popup> _popupsStack;
        
        public override void Initialize()
        {
            _popupsStack = new Stack<Popup>();
            foreach (var popup in _popups)
            {
                popup.Initialize();
            }
        }

        public IEnumerator ShowPopup<T>() where T : Popup
        {
            var popup = _popups.First(p => p is T);
            _popupsStack.Push(popup);
            yield return popup.ShowPopup();
        }

        public IEnumerator PushPopup<T>() where T : Popup
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
            foreach (var popup in _popupsStack)
            {
                yield return popup.HidePopup();
            }
            _popupsStack.Clear();
        }
    }
}