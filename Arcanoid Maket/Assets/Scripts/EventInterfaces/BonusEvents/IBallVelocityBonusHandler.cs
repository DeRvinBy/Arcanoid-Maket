using GameEntities.Ball;
using GameEntities.Bonuses.Enumerations;
using MyLibrary.EventSystem;

namespace EventInterfaces.BonusEvents
{
    public interface IBallVelocityBonusHandler : IGlobalSubscriber
    {
        void ActivateVelocityBonus(ValueModifer modifer);
    }
}