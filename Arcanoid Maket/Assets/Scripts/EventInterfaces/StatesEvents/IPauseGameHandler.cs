using Scripts.Utils.EventSystem;

namespace EventInterfaces.StatesEvents
{
    public interface IPauseGameHandler : IGlobalSubscriber
    {
        void OnPause();
        void OnContinue();
    }
}