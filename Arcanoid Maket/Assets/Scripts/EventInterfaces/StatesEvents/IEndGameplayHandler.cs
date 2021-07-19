using Scripts.Utils.EventSystem;

namespace Scripts.EventInterfaces.StatesEvents
{
    public interface IEndGameplayHandler : IGlobalSubscriber
    {
        void OnEndGame();
    }
}