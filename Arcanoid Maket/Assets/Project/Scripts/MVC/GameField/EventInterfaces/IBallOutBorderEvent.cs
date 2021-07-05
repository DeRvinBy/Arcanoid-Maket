using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.MVC.GameField.EventInterfaces
{
    public interface IBallOutBorderEvent : IGlobalSubscriber
    {
        void OnBallOut();
    }
}