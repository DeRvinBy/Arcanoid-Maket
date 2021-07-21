using GameEntities.Bonuses.Enumerations;
using MyLibrary.EventSystem;

namespace EventInterfaces.BonusEvents
{
    public interface IPlatformSpeedBonusHandler : IGlobalSubscriber
    {
        void ActivateSpeedBonus(ValueModifer modifer);
    }
}