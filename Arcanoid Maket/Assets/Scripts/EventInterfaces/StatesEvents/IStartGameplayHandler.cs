using Scripts.Utils.EventSystem;

namespace Scripts.EventInterfaces.StatesEvents
{
    public interface IStartGameplayHandler : IGlobalSubscriber
    {
        void OnStartGame();
    }
}