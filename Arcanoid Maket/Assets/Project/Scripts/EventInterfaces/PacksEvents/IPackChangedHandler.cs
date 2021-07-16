using Project.Scripts.Packs.Data.Packs;
using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.EventInterfaces.PacksEvents
{
    public interface IPackChangedHandler : IGlobalSubscriber
    {
        void OnPackChanged(PackInfo currentPack);
    }
}