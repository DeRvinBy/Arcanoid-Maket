using System.Collections.Generic;
using Project.Scripts.EventInterfaces.PacksEvents;
using Project.Scripts.Packs.Data.Packs;
using Project.Scripts.UI.Packs;
using Project.Scripts.Utils.EventSystem;
using Project.Scripts.Utils.UI.Popup.Abstract;
using UnityEngine;

namespace Project.Scripts.UI.Popups
{
    public class PackChoosingPopup : AbstractPopup, IPacksInfoHandler
    {
        [SerializeField]
        private UIPacksManager _manager;
        
        public override void Initialize()
        {
            base.Initialize();
            
            EventBus.Subscribe(this);
        }

        public void OnPacksInfoUpdated(Dictionary<string, PackInfo> packsInfo)
        {
            _manager.UpdatePackContainers(packsInfo);
        }
    }
}