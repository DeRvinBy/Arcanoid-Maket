using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.MVC.Test.Interfaces
{
    public interface IGameEndedEvent : IGlobalSubscriber
    {
        void EndGame();
    }
}