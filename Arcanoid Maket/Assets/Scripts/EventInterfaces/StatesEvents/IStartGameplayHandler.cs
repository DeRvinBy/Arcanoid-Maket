using Scripts.Utils.EventSystem;

namespace EventInterfaces.StatesEvents
{
    public interface IStartGameplayHandler : IGlobalSubscriber
    {
        void OnStartGame();
    }
}