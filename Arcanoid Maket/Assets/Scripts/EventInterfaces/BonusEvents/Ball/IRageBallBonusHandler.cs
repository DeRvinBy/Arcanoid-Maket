using MyLibrary.EventSystem;

namespace EventInterfaces.BonusEvents.Ball
{
    public interface IRageBallBonusHandler : IGlobalSubscriber
    {
        void OnActivateRageBonus();
    }
}