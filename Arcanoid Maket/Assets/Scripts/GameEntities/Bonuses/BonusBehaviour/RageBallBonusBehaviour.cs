using EventInterfaces.BonusEvents;
using GameEntities.Bonuses.Interfaces;
using MyLibrary.EventSystem;

namespace GameEntities.Bonuses.BonusBehaviour
{
    public class RageBallBonusBehaviour : IBonusBehaviour
    {
        public void Action()
        {
            EventBus.RaiseEvent<IRageBallBonusHandler>(a => a.OnActivateRageBonus());
        }
    }
}