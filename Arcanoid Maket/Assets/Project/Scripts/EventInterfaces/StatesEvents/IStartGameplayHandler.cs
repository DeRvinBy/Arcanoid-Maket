using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.EventInterfaces.StatesEvents
{
    public interface IStartGameplayHandler : IGlobalSubscriber
    {
        void OnStartGame();
    }
}