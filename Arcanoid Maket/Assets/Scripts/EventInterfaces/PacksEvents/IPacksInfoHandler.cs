using System.Collections.Generic;
using GamePacks.Data.Packs;
using Scripts.Utils.EventSystem;

namespace EventInterfaces.PacksEvents
{
    public interface IPacksInfoHandler : IGlobalSubscriber
    {
        void OnPacksInfoUpdated(Dictionary<string, PackInfo> packsInfo);
    }
}