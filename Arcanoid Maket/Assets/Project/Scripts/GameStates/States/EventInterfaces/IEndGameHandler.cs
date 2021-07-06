using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.GameStates.States.EventInterfaces
{
    public interface IEndGameHandler : IGlobalSubscriber
    {
        public void WinGame();
        public void EndGame();
    }
}