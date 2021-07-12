using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.EventInterfaces.GameEvents
{
    public interface IStartGameHandler : IGlobalSubscriber
    {
        void OnStartGameProcess();
    }
}