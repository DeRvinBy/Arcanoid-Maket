using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.EventInterfaces.StatesInterfaces
{
    public interface IMainGameStateEvent : IGlobalSubscriber
    {
        void StartController();
    }
}