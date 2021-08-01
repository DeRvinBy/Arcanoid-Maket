using EventInterfaces.BlockEvents;
using GameEntities.Blocks.Abstract;
using GameEntities.Blocks.Enumerations;
using GameSettings.GameBlockSettings;
using MyLibrary.EventSystem;

namespace GameEntities.Blocks
{
    public class ColorBlock : DestructibleBlock
    {
        public BlockSpriteId BlockColor { get; private set; }

        public override void Initialize(BlockSettings settings)
        {
            base.Initialize(settings);
            BlockType = BlockType.ColorBlock;
        }

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