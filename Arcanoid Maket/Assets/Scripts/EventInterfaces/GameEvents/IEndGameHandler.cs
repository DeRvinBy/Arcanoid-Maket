using Scripts.Utils.EventSystem;

namespace Scripts.EventInterfaces.GameEvents
{
    public interface IEndGameHandler : IGlobalSubscriber
    {
        void OnWinGame();
        void OnLoseGame();
    }
}