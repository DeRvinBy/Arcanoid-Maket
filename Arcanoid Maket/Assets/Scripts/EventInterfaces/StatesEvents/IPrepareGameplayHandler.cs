using Scripts.Utils.EventSystem;

namespace Scripts.EventInterfaces.StatesEvents
{
    public interface IPrepareGameplayHandler : IGlobalSubscriber
    {
        void OnPrepareGame();
    }
}