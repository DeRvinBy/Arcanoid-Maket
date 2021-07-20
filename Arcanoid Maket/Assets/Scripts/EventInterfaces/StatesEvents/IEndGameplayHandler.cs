using MyLibrary.EventSystem;

namespace EventInterfaces.StatesEvents
{
    public interface IEndGameplayHandler : IGlobalSubscriber
    {
        void OnEndGame();
    }
}