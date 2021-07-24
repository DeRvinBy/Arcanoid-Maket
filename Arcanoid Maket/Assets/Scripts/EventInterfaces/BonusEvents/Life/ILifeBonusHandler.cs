using GameEntities.Bonuses.Enumerations;
using MyLibrary.EventSystem;

namespace EventInterfaces.BonusEvents.Life
{
    public interface ILifeBonusHandler : IGlobalSubscriber
    {
        void OnActivateLifeBonus(ValueModifer modifer);
    }
}