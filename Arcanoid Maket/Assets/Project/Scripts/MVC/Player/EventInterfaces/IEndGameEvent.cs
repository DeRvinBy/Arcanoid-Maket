using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.MVC.Player.EventInterfaces
{
    public interface IEndGameEvent : IGlobalSubscriber
    {
        void OnEndGame();
    }
}