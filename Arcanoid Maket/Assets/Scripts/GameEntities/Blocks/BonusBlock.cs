using EventInterfaces.BlockEvents;
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
            print("destroy");
        }
        
        protected override void OnDestroyBlock()
        {
            EventBus.RaiseEvent<IBlockOnSceneHandler>(a => a.OnDestroyBlock(this));   
        }
    }
}