using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.EventInterfaces.GameEvents
{
    public interface IPlayerBallsEndedHandler : IGlobalSubscriber
    {
        void OnPlayerBallsEnded();
    }
}