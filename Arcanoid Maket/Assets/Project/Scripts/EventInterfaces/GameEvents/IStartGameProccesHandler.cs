using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.EventInterfaces.GameEvents
{
    public interface IStartGameProccesHandler : IGlobalSubscriber
    {
        void OnStartGameProcess();
    }
}