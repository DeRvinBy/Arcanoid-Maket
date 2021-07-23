using MyLibrary.EventSystem;

namespace EventInterfaces.BonusEvents
{
    public interface IRageBallBonusHandler : IGlobalSubscriber
    {
        void ActivateRageBonus();
    }
}