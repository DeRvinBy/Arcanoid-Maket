using System.Collections.Generic;
using Scripts.EventInterfaces.PacksEvents;
using Scripts.EventInterfaces.StatesEvents;
using Scripts.GamePacks.Data.Packs;
using Scripts.UI.Packs;
using Scripts.Utils.EventSystem;
using Scripts.Utils.UI.Button;
using Scripts.Utils.UI.Popup.Abstract;
using UnityEngine;

namespace Scripts.UI.Popups
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