using GameEntities.Bonuses.Enumerations;
using MyLibrary.EventSystem;

namespace EventInterfaces.BonusEvents.Platform
{
    public interface IPlatformSizeBonusHandler : IGlobalSubscriber
    {
        void OnActivateSizeBonus(ValueModifer modifer);
    }
}