using System.Collections.Generic;
using Scripts.GamePacks.Data.Packs;
using Scripts.Utils.EventSystem;

namespace Scripts.EventInterfaces.PacksEvents
{
    public interface IPacksInfoHandler : IGlobalSubscriber
    {
        void OnPacksInfoUpdated(Dictionary<string, PackInfo> packsInfo);
    }
}