using EventInterfaces.BlockEvents;
using GameEntities.Blocks.Enumerations;
using MyLibrary.EventSystem;

namespace GameEntities.Blocks
{
    public class ColorBlock : DestructibleBlock
    {
        public BlockSpriteId BlockColor { get; private set; }

        public override void SetupBlock(BlockSpriteId spriteId)
        {
            base.SetupBlock(spriteId);
            BlockColor = spriteId;
        }

        protected override void DestroyCompleteBlock()
        {
            EventBus.RaiseEvent<IBlockOnSceneHandler>(a => a.OnDestroyBlock(this));  
        }
    }
}