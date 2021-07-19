using Scripts.Utils.EventSystem;

namespace EventInterfaces.StatesEvents
{
    public interface IEndGameplayHandler : IGlobalSubscriber
    {
        void OnEndGame();
    }
}