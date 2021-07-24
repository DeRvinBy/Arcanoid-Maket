using EventInterfaces.BonusEvents.Ball;
using GameEntities.Bonuses.BonusBehaviour.Abstract;
using GameEntities.Bonuses.Enumerations;
using MyLibrary.EventSystem;

namespace GameEntities.Bonuses.BonusBehaviour.Ball
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