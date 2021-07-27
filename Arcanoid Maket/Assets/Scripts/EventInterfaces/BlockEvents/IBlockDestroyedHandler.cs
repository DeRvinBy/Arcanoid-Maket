using MyLibrary.EventSystem;

namespace EventInterfaces.BlockEvents
{
    public interface IBlockDestroyedHandler : IGlobalSubscriber
    {
        void OnBlockDestroy();
    }
}