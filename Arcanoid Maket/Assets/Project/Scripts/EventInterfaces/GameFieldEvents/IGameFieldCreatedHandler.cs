using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.EventInterfaces.GameFieldEvents
{
    public interface IGameFieldCreatedHandler : IGlobalSubscriber
    {
        void OnBlocksCreated(int blockCount);
    }
}