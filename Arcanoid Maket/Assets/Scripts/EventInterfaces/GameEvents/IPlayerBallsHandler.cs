using MyLibrary.EventSystem;

namespace EventInterfaces.GameEvents
{
    public interface IPlayerBallsHandler : IGlobalSubscriber
    {
        void OnPlayerBallLose();
    }
}