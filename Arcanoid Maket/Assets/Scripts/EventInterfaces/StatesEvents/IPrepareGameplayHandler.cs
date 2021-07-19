using Library.EventSystem;

namespace EventInterfaces.StatesEvents
{
    public interface IPrepareGameplayHandler : IGlobalSubscriber
    {
        void OnPrepareGame();
    }
}