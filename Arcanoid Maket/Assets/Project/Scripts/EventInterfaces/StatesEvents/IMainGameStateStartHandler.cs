using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.EventInterfaces.StatesEvents
{
    public interface IMainGameStateStartHandler : IGlobalSubscriber
    {
        void OnStartGame();
    }
}