using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.GameStates.States.EventInterfaces
{
    public interface IMainGameStateEvent : IGlobalSubscriber
    {
        void StartGame();
    }
}