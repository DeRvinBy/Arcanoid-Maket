using EventInterfaces.BonusEvents;
using GameEntities.Bonuses.BonusBehaviour.Abstract;
using GameEntities.Bonuses.Enumerations;
using MyLibrary.EventSystem;

namespace GameEntities.Bonuses.BonusBehaviour
{
    public class BallVelocityBonusBehaviour : ValueModiferBonusBehaviour
    {
        public BallVelocityBonusBehaviour(ValueModifer modifer) : base(modifer)
        {
        }
        
        public override void Action()
        {
            EventBus.RaiseEvent<IBallVelocityBonusHandler>(a => a.OnActivateVelocityBonus(_modifer));
        }
    }
}