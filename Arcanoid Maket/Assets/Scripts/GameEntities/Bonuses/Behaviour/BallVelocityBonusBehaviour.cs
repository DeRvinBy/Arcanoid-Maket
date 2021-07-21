using EventInterfaces.BonusEvents;
using GameEntities.Bonuses.Enumerations;
using GameEntities.Bonuses.Interfaces;
using MyLibrary.EventSystem;

namespace GameEntities.Bonuses.Behaviour
{
    public class BallVelocityBonusBehaviour : IBonusBehaviour
    {
        private ValueModifer _modifer;
        
        public BallVelocityBonusBehaviour(ValueModifer modifer)
        {
            _modifer = modifer;
        }
        
        public void Action()
        {
            EventBus.RaiseEvent<IBallBonusHandler>(a => a.ActivateVelocityBonus(_modifer));
        }
    }
}