using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.EventInterfaces.GameEvents
{
    public interface IEndGameHandler : IGlobalSubscriber
    {
        public void OnWinGame();
        public void OnEndGame();
    }
}