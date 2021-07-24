using GameEntities.Bonuses.Enumerations;
using MyLibrary.EventSystem;

namespace EventInterfaces.BonusEvents.Platform
{
    public interface IPlatformSpeedBonusHandler : IGlobalSubscriber
    {
        void OnActivateSpeedBonus(ValueModifer modifer);
    }
}