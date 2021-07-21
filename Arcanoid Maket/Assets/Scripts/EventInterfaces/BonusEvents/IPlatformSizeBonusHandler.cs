using GameEntities.Bonuses.Enumerations;
using MyLibrary.EventSystem;

namespace EventInterfaces.BonusEvents
{
    public interface IPlatformSizeBonusHandler : IGlobalSubscriber
    {
        void ActivateSizeBonus(ValueModifer modifer);
    }
}