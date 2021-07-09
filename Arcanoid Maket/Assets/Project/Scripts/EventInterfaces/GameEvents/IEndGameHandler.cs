using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.EventInterfaces.GameEvents
{
    public interface IEndGameHandler : IGlobalSubscriber
    {
        void OnWinGame();
        void OnLoseGame();
    }
}