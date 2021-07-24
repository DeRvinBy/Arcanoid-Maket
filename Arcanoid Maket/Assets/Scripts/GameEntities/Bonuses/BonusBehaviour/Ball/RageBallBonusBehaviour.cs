using EventInterfaces.BonusEvents.Ball;
using GameEntities.Bonuses.Interfaces;
using MyLibrary.EventSystem;

namespace GameEntities.Bonuses.BonusBehaviour.Ball
{
    public class RageBallBonusBehaviour : IBonusBehaviour
    {
        public void Action()
        {
            EventBus.RaiseEvent<IRageBallBonusHandler>(a => a.OnActivateRageBonus());
        }
    }
}