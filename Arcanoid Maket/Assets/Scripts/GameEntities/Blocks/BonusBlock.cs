using System;
using EventInterfaces.BlockEvents;
using MyLibrary.EventSystem;

namespace GameEntities.Blocks
{
    public class BonusBlock : DestructibleBlock
    {
        public event Action OnBlockDestroy;

        public override void OnReset()
        {
            base.OnReset();
            OnBlockDestroy = null;
        }

        public override void DestroyBlock()
        {
            base.DestroyBlock();
            OnBlockDestroy?.Invoke();
        }
        
        protected override void DestroyCompleteBlock()
        {
            EventBus.RaiseEvent<IBlockOnSceneHandler>(a => a.OnDestroyBlock(this));   
        }
    }
}