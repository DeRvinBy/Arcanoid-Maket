using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.EventInterfaces.StatesEvents
{
    public interface IPauseGameHandler : IGlobalSubscriber
    {
        void OnPause();
        void OnContinue();
    }
}