using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.EventInterfaces.GameFieldEvents
{
    public interface IBallOutBorderEvent : IGlobalSubscriber
    {
        void OnBallOut();
    }
}