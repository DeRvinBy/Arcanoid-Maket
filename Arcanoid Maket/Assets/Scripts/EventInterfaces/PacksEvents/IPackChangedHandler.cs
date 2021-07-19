using GamePacks.Data.Packs;
using Library.EventSystem;

namespace EventInterfaces.PacksEvents
{
    public interface IPackChangedHandler : IGlobalSubscriber
    {
        void OnPackChanged(PackInfo currentPack);
    }
}