using Scripts.Utils.EventSystem;

namespace Scripts.EventInterfaces.GameEvents
{
    public interface IContinueGameHandler : IGlobalSubscriber
    {
        void OnContinueGame();
    }
}