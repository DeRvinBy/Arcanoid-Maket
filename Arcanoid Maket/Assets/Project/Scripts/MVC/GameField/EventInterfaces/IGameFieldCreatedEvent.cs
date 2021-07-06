using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.MVC.GameField.EventInterfaces
{
    public interface IGameFieldCreatedEvent : IGlobalSubscriber
    {
        void OnBlocksCreated(int blockCount);
    }
}