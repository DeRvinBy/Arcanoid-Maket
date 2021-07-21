using EventInterfaces.BlockEvents;
using EventInterfaces.BonusEvents;
using GameEntities.Bonuses.Enumerations;
using MyLibrary.EventSystem;

namespace GameEntities.Blocks
{
    public class BonusBlock : DestructibleBlock
    {
        private BonusType _bonusType;
        
        public void SetupBonus(BonusType bonus)
        {
            _bonusType = bonus;
        }
        
        public override void DestroyBlock()
        {
            base.DestroyBlock();
            EventBus.RaiseEvent<IBonusOnSceneHandler>(a => a.OnCreateBonusObject(_bonusType, transform.position));
        }
        
        protected override void DestroyCompleteBlock()
        {
            EventBus.RaiseEvent<IBlockOnSceneHandler>(a => a.OnDestroyBlock(this));   
        }
    }
}