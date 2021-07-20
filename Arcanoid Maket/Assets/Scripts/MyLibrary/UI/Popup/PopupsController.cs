﻿using System;
using System.Collections;
using System.Collections.Generic;
using BehaviorControllers.Abstract;
using MyLibrary.ObjectPool;
using MyLibrary.UI.Popup.Abstract;
using UnityEngine;

namespace MyLibrary.UI.Popup
{
    public class PopupsController : EntityController
    {
        [SerializeField]
        private Transform _popupsUIContainer;
        
        private Dictionary<Type, AbstractPopup> _popupsMap;

        private Stack<AbstractPopup> _popupsStack;

        public override void Initialize()
        {
            _popupsMap = new Dictionary<Type, AbstractPopup>();
            _popupsStack = new Stack<AbstractPopup>();
        }

        public IEnumerator ShowPopup<T>() where T : AbstractPopup
        {
            var popup = GetPopupByType<T>();
            popup.transform.SetAsLastSibling();
            _popupsStack.Push(popup);
            yield return popup.ShowPopup();
        }

        private AbstractPopup GetPopupByType<T>() where T : AbstractPopup
        {
            var type = typeof(T);
            if (!_popupsMap.ContainsKey(type))
            {
                var popup = PoolsManager.Instance.GetObject<T>(Vector3.zero, _popupsUIContainer);
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
            yield return popup.HidePopup();
        }

        public IEnumerator HideAllActivePopups()
        {
            for (int i = 0; i < _popupsStack.Count; i++)
            {
                var popup = _popupsStack.Pop();
                yield return popup.HidePopup();
            }
            _popupsStack.Clear();
        }

        public void ClearPopups()
        {
            foreach (var pair in _popupsMap)
            {
                PoolsManager.Instance.ReturnObject(pair.Key, pair.Value);
            }
        }
    }
}