using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.EventInterfaces.GameEvents
{
    public interface IStartGameplayHandler : IGlobalSubscriber
    {
        void OnStartGameProcess();
    }
}