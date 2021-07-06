using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.EventInterfaces.StatesEvents
{
    public interface IMainGameStateEndHandler : IGlobalSubscriber
    {
        void OnEndGame();
    }
}