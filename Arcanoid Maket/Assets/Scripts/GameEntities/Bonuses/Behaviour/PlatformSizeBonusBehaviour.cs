using EventInterfaces.BonusEvents;
using GameEntities.Bonuses.Behaviour.Abstract;
using GameEntities.Bonuses.Enumerations;
using MyLibrary.EventSystem;

namespace GameEntities.Bonuses.Behaviour
{
    public class PlatformSizeBonusBehaviour : ValueModiferBonusBehaviour
    {
        public PlatformSizeBonusBehaviour(ValueModifer modifer) : base(modifer)
        {
        }
        
        public override void Action()
        {
            EventBus.RaiseEvent<IPlatformSizeBonusHandler>(a => a.ActivateSizeBonus(_modifer));
        }
    }
}