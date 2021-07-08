using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.EventInterfaces.GameEvents
{
    public interface ILoseGameHandler : IGlobalSubscriber
    {
        public void OnLoseGame();
    }
}