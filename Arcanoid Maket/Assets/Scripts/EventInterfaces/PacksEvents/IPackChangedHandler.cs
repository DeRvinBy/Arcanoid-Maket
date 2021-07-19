using GamePacks.Data.Packs;
using Scripts.Utils.EventSystem;

namespace EventInterfaces.PacksEvents
{
    public interface IPackChangedHandler : IGlobalSubscriber
    {
        void OnPackChanged(PackInfo currentPack);
    }
}