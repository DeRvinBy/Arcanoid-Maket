using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.EventInterfaces.PacksEvents
{
    public interface ILevelCompleteHandler : IGlobalSubscriber
    {
        void OnLevelComplete();
    }
}