using Scripts.Utils.EventSystem;

namespace EventInterfaces.GameEvents
{
    public interface IContinueGameHandler : IGlobalSubscriber
    {
        void OnContinueGame();
    }
}