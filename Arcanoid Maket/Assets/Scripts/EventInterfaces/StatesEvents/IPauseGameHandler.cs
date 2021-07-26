using MyLibrary.EventSystem;

namespace EventInterfaces.StatesEvents
{
    public interface IPauseGameHandler : IGlobalSubscriber
    {
        void OnStartTime();
        void OnPause();
        void OnContinue();
    }
}