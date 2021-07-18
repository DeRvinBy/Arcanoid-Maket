using Scripts.Utils.EventSystem;

namespace Scripts.EventInterfaces.GameEvents
{
    public interface IStartGameHandler : IGlobalSubscriber
    {
        void OnStartGameProcess();
    }
}