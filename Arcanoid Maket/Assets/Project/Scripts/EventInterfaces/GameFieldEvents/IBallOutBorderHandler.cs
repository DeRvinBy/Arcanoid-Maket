using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.EventInterfaces.GameFieldEvents
{
    public interface IBallOutBorderHandler : IGlobalSubscriber
    {
        void OnBallOut();
    }
}