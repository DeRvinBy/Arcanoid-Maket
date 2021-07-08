using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Project.Scripts.Architecture.Abstract;
using Project.Scripts.UI.PopupUI.Abstract;
using UnityEngine;

namespace Project.Scripts.UI.PopupUI
{
    public class PopupsController : SceneEntitiesController
    {
        [SerializeField]
        private Popup[] _popups;

        private List<Popup> _activePopups;
        
        public override void Initialize()
        {
            _activePopups = new List<Popup>();
            foreach (var popup in _popups)
            {
                popup.Initialize();
            }
        }

        public bool IsExistActivePopups()
        {
            return _activePopups.Count != 0;
        }
        
        public IEnumerator ShowPopup<T>() where T : Popup
        {
            var popup = _popups.First(p => p is T);
            _activePopups.Add(popup);
            return popup.ShowPopup();
        }
        
        public void StartPopup<T>() where T : Popup
        {
             _popups.First(p => p is T).StartPopup();
        }
        
        public IEnumerator HideAllActivePopups()
        {
            foreach (var popup in _activePopups)
            {
                yield return popup.HidePopup();
            }
            _activePopups.Clear();
        }
    }
}