using System.Collections.Generic;
using EventInterfaces.PacksEvents;
using EventInterfaces.StatesEvents;
using GamePacks.Data.Packs;
using Library.EventSystem;
using Library.UI.Button;
using Library.UI.Popup.Abstract;
using UI.Packs;
using UnityEngine;

namespace UI.Popups
{
    public class PackChoosingPopup : AbstractPopup, IPacksInfoHandler
    {
        [SerializeField]
        private UIPacksManager _manager;

        [SerializeField]
        private EventButton _backButton;

        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }
        
        private void OnDisable()
        {
            EventBus.Subscribe(this);
        }

        protected override void StartPopup()
        {
            _backButton.Enable();
            _backButton.OnButtonPressed += OnBack;
        }
        
        protected override void ResetPopup()
        {
            _backButton.Disable();
            _backButton.OnButtonPressed -= OnBack;
        }
        
        private void OnBack()
        {
            EventBus.RaiseEvent<IPacksChoosingHandler>(a => a.OnCancelChoosePack());
        }

        public void OnPacksInfoUpdated(Dictionary<string, PackInfo> packsInfo)
        {
            _manager.UpdatePackContainers(packsInfo);
        }
    }
}