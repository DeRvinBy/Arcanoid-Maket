using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.EventInterfaces.GameEvents
{
    public interface IWinGameHandler : IGlobalSubscriber
    {
        public void OnWinGame();
    }
}