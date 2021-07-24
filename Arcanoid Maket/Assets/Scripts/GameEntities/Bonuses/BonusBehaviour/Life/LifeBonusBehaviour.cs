using EventInterfaces.BonusEvents.Life;
using GameEntities.Bonuses.BonusBehaviour.Abstract;
using GameEntities.Bonuses.Enumerations;
using MyLibrary.EventSystem;

namespace GameEntities.Bonuses.BonusBehaviour.Life
{
    public class LifeBonusBehaviour : ValueModiferBonusBehaviour
    {
        public LifeBonusBehaviour(ValueModifer modifer) : base(modifer)
        {
        }

        public override void Action()
        {
            EventBus.RaiseEvent<ILifeBonusHandler>(a => a.OnActivateLifeBonus(_modifer));
        }
    }
}