using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.EventInterfaces.GameEvents
{
    public interface IContinueGameHandler : IGlobalSubscriber
    {
        void OnContinueGame();
    }
}