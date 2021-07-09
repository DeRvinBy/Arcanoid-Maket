using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.EventInterfaces.StatesEvents
{
    public interface IEndGameplayHandler : IGlobalSubscriber
    {
        void OnEndGame();
    }
}