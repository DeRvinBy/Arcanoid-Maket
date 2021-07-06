using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.EventInterfaces.GameEvents
{
    public interface IContinueGameEvent : IGlobalSubscriber
    {
        void OnContinueGame();
    }
}