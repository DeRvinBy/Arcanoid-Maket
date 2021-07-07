using System.Collections;
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

        public override void Initialize()
        {
            foreach (var popup in _popups)
            {
                popup.Initialize();
            }
        }

        public IEnumerator ShowPopup<T>() where T : Popup
        {
            var popup = _popups.First(p => p is T);
            return popup.ShowPopup();
        }
        
        public void StartPopup<T>() where T : Popup
        {
             _popups.First(p => p is T).StartPopup();
        }
        
        public IEnumerator HidePopup<T>() where T : Popup
        {
            return _popups.First(p => p is T).HidePopup();
        }
    }
}