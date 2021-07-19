using Scripts.Utils.EventSystem;

namespace Scripts.EventInterfaces.StatesEvents
{
    public interface IPauseGameHandler : IGlobalSubscriber
    {
        void OnPause();
        void OnContinue();
    }
}