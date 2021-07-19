using Scripts.Utils.EventSystem;

namespace EventInterfaces.StatesEvents
{
    public interface IPrepareGameplayHandler : IGlobalSubscriber
    {
        void OnPrepareGame();
    }
}