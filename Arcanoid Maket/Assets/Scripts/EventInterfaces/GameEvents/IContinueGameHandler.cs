using MyLibrary.EventSystem;

namespace EventInterfaces.GameEvents
{
    public interface IContinueGameHandler : IGlobalSubscriber
    {
        void OnContinueGame();
    }
}