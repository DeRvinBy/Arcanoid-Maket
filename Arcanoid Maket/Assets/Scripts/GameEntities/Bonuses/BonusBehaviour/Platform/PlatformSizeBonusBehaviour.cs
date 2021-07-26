using EventInterfaces.BonusEvents.Platform;
using GameEntities.Bonuses.BonusBehaviour.Abstract;
using GameEntities.Bonuses.Enumerations;
using MyLibrary.EventSystem;

namespace GameEntities.Bonuses.BonusBehaviour.Platform
{
    public class PlatformSizeBonusBehaviour : ValueModiferBonusBehaviour
    {
        public PlatformSizeBonusBehaviour(ValueModifer modifer) : base(modifer)
        {
        }
        
        public override void Action()
        {
            EventBus.RaiseEvent<IPlatformSizeBonusHandler>(a => a.OnActivateSizeBonus(_modifer));
        }
    }
}