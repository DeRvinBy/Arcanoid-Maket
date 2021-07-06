using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.EventInterfaces.BlockEvents
{
    public interface IBlockDestroyedHandler : IGlobalSubscriber
    {
        void OnBlockDestroyed();
    }
}