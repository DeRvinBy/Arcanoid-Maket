using GameEntities.Bonuses.Enumerations;
using MyLibrary.EventSystem;

namespace EventInterfaces.BonusEvents.Ball
{
    public interface IBallVelocityBonusHandler : IGlobalSubscriber
    {
        void OnActivateVelocityBonus(ValueModifer modifer);
    }
}