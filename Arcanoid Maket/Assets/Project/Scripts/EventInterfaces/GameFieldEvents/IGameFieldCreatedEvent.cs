using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.EventInterfaces.GameFieldEvents
{
    public interface IGameFieldCreatedEvent : IGlobalSubscriber
    {
        void OnBlocksCreated(int blockCount);
    }
}