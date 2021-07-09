using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.EventInterfaces.GameEvents
{
    public interface ILevelCompleteHandler : IGlobalSubscriber
    {
        void OnLevelComplete();
    }
}