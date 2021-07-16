using System.Collections.Generic;
using Project.Scripts.Packs.Data.Packs;
using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.EventInterfaces.PacksEvents
{
    public interface IPacksInfoHandler : IGlobalSubscriber
    {
        void OnPacksInfoUpdated(Dictionary<string, PackInfo> packsInfo);
    }
}