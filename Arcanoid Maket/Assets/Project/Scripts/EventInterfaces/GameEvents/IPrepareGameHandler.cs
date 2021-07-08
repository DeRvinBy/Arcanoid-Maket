using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.EventInterfaces.GameEvents
{
    public interface IPrepareGameHandler : IGlobalSubscriber
    {
        void OnPrepareGame();
    }
}