using EventInterfaces.BonusEvents;
using GameEntities.Bonuses.BonusBehaviour.Abstract;
using GameEntities.Bonuses.Enumerations;
using MyLibrary.EventSystem;

namespace GameEntities.Bonuses.BonusBehaviour
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