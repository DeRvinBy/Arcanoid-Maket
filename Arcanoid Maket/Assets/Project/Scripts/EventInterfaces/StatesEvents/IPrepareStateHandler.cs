using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.EventInterfaces.StatesEvents
{
    public interface IPrepareStateHandler : IGlobalSubscriber
    {
        void OnPrepareGame();
    }
}