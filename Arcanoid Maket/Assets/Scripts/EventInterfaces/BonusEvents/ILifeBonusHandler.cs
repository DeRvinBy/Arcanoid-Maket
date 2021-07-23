using GameEntities.Bonuses.Enumerations;
using MyLibrary.EventSystem;

namespace EventInterfaces.BonusEvents
{
    public interface ILifeBonusHandler : IGlobalSubscriber
    {
        void OnActivateLifeBonus(ValueModifer modifer);
    }
}