using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.MVC.Player.EventInterfaces
{
    public interface IContinueGameEvent : IGlobalSubscriber
    {
        void ContinueGame();
    }
}