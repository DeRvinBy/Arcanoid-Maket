using System.Collections.Generic;
using Project.Scripts.EventInterfaces.PacksEvents;
using Project.Scripts.EventInterfaces.StatesEvents;
using Project.Scripts.Packs.Data.Packs;
using Project.Scripts.UI.Packs;
using Project.Scripts.Utils.EventSystem;
using Project.Scripts.Utils.UI.Button;
using Project.Scripts.Utils.UI.Popup.Abstract;
using UnityEngine;

namespace Project.Scripts.UI.Popups
{
    public class PackChoosingPopup : AbstractPopup, IPacksInfoHandler
    {
        [SerializeField]
        private UIPacksManager _manager;

        [SerializeField]
        private EventButton _backButton;
        
        public override void Initialize()
        {
            base.Initialize();
            _backButton.OnButtonPressed += OnBack;
            
            EventBus.Subscribe(this);
        }

        protected override void StartPopup()
        {
            base.StartPopup();
            _backButton.Enable();
        }
        
        protected override void ResetPopup()
        {
            base.ResetPopup();
            _backButton.Disable();
        }

        public void OnPacksInfoUpdated(Dictionary<string, PackInfo> packsInfo)
        {
            _manager.UpdatePackContainers(packsInfo);
        }

        private void OnBack()
        {
            EventBus.RaiseEvent<IPacksUIHandler>(a => a.OnCancelChoosePack());
        }
    }
}