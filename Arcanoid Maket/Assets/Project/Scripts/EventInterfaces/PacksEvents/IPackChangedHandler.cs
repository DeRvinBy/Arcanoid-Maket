using Project.Scripts.Packs.Data.Game;
using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.EventInterfaces.PacksEvents
{
    public interface IPackChangedHandler : IGlobalSubscriber
    {
        void OnPackChanged(Pack currentPack);
    }
}