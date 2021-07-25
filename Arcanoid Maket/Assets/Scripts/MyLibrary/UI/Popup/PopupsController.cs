using System;
using System.Collections;
using System.Collections.Generic;
using MyLibrary.ObjectPool;
using MyLibrary.Singleton;
using MyLibrary.UI.Popup.Abstract;
using MyLibrary.UI.Popup.Components;
using UnityEngine;

namespace MyLibrary.UI.Popup
{
    public class PopupsController : Singleton<PopupsController>
    {
        private PopupsLocker _popupsLocker;
        private Transform _popupsContainer;

        private Dictionary<Type, AbstractPopup> _popupsMap;
        private Stack<AbstractPopup> _popupsStack;
        
        protected override void Initialize()
        {
            _popupsMap = new Dictionary<Type, AbstractPopup>();
            _popupsStack = new Stack<AbstractPopup>();
            CreatePopupsContainer();
        }

        private void CreatePopupsContainer()
        {
            var container = PoolsManager.Instance.GetObject<PopupsContainer>(Vector3.zero);
            _popupsLocker = container.PopupsLocker;
            _popupsContainer = container.transform;
        }

        public IEnumerator ShowPopup<T>() where T : AbstractPopup
        {
            var popup = GetPopupByType<T>();
            popup.transform.SetAsLastSibling();
            _popupsLocker.EnableLocker();
            _popupsLocker.MoveUpLocker(popup.transform);
            _popupsStack.Push(popup);
            yield return popup.ShowPopup();
            _popupsLocker.MoveDownLocker(popup.transform);
        }

        private AbstractPopup GetPopupByType<T>() where T : AbstractPopup
        {
            var type = typeof(T);
            if (!_popupsMap.ContainsKey(type))
            {
                var popup = PoolsManager.Instance.GetObject<T>(Vector3.zero, _popupsContainer);
                var rectTransform = (RectTransform)popup.transform;
                rectTransform.anchoredPosition = Vector2.zero;
                rectTransform.localScale = Vector3.one;
                rectTransform.sizeDelta = Vector2.zero;
                _popupsMap.Add(type, popup);
            }
            
            return _popupsMap[type];
        }

        public IEnumerator PushPopup<T>() where T : AbstractPopup
        {
            yield return HideLastPopup();
            yield return ShowPopup<T>();
        }

        public IEnumerator HideLastPopup()
        {
            var popup = _popupsStack.Pop();
            _popupsLocker.MoveUpLocker(popup.transform);
            yield return popup.HidePopup();
            if (_popupsStack.Count != 0)
            {
                _popupsLocker.MoveDownLocker(popup.transform);
            }
            else
            {
                _popupsLocker.DisableLocker();
            }
        }

        public IEnumerator HideAllActivePopups()
        {
            _popupsLocker.MoveOnAllPopups();
            for (int i = 0; i < _popupsStack.Count; i++)
            {
                var popup = _popupsStack.Pop();
                yield return popup.HidePopup();
            }
            _popupsStack.Clear();
            _popupsLocker.DisableLocker();
        }

        public void ClearPopups()
        {
            foreach (var pair in _popupsMap)
            {
                PoolsManager.Instance.ReturnObject(pair.Key, pair.Value);
            }
            _popupsMap.Clear();
            _popupsStack.Clear();
        }
    }
}