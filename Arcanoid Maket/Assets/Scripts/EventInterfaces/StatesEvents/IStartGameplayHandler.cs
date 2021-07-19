using Library.EventSystem;

namespace EventInterfaces.StatesEvents
{
    public interface IStartGameplayHandler : IGlobalSubscriber
    {
        void OnStartGame();
    }
}