using MyLibrary.EventSystem;

namespace EventInterfaces.GameEvents
{
    public interface IStartGameHandler : IGlobalSubscriber
    {
        void OnStartGameProcess();
        void OnRestartGameProcess();
        void OnContinueAfterLoseGameProcess();
    }
}