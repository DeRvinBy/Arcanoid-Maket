using GameEntities.Bonuses.Enumerations;
using MyLibrary.EventSystem;

namespace EventInterfaces.BonusEvents
{
    public interface IBallBonusHandler : IGlobalSubscriber
    {
        void ActivateVelocityBonus(ValueModifer modifer);
    }
}