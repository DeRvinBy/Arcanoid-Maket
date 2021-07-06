using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.MVC.Blocks.EventInterfaces
{
    public interface IBlockDestroyedEvent : IGlobalSubscriber
    {
        void OnBlockDestroyed();
    }
}