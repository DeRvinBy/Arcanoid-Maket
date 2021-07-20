using GamePacks.Data.Packs;
using MyLibrary.EventSystem;

namespace EventInterfaces.PacksEvents
{
    public interface IPackChangedHandler : IGlobalSubscriber
    {
        void OnPackChanged(PackInfo currentPack);
    }
}