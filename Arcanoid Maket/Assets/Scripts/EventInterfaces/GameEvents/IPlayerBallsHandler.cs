using Scripts.Utils.EventSystem;

namespace Scripts.EventInterfaces.GameEvents
{
    public interface IPlayerBallsHandler : IGlobalSubscriber
    {
        void OnPlayerBallLose();
    }
}