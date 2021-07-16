using System.Collections.Generic;
using Project.Scripts.EventInterfaces.PacksEvents;
using Project.Scripts.Packs.Data.Packs;
using Project.Scripts.Utils.UI.Popup.Abstract;

namespace Project.Scripts.UI.Popups
{
    public class PackChoosingPopup : AbstractPopup, IPacksInfoHandler
    {
        public void OnPacksInfoUpdated(Dictionary<string, PackInfo> packsInfo)
        {
            
        }
    }
}