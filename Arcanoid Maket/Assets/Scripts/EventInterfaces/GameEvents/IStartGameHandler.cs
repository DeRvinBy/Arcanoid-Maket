using Scripts.Utils.EventSystem;

namespace EventInterfaces.GameEvents
{
    public interface IStartGameHandler : IGlobalSubscriber
    {
        void OnStartGameProcess();
    }
}