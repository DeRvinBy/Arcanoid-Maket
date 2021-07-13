using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.EventInterfaces.StatesEvents
{
    public interface IPrepareGameplayHandler : IGlobalSubscriber
    {
        void OnPrepareGame();
    }
}