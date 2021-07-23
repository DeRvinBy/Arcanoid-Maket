using EventInterfaces.BonusEvents;
using GameEntities.Bonuses.BonusBehaviour.Abstract;
using GameEntities.Bonuses.Enumerations;
using MyLibrary.EventSystem;

namespace GameEntities.Bonuses.BonusBehaviour
{
    public class PlatformSpeedBonusBehaviour : ValueModiferBonusBehaviour
    {
        public PlatformSpeedBonusBehaviour(ValueModifer modifer) : base(modifer)
        {
        } 
        
        public override void Action()
        {
            EventBus.RaiseEvent<IPlatformSpeedBonusHandler>(a => a.OnActivateSpeedBonus(_modifer));
        }
    }
}