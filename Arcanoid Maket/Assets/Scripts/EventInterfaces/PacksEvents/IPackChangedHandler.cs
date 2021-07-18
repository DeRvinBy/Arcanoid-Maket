using Scripts.GamePacks.Data.Packs;
using Scripts.Utils.EventSystem;

namespace Scripts.EventInterfaces.PacksEvents
{
    public interface IPackChangedHandler : IGlobalSubscriber
    {
        void OnPackChanged(PackInfo currentPack);
    }
}