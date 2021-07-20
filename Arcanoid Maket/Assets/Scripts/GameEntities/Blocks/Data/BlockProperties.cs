using GameEntities.Blocks.Enumerations;

namespace GameEntities.Blocks.Data
{
    public class BlockProperties
    {
        public BlockType Type { get; set; }
        public BlockSpriteId SpriteId { get; set; }
        public int BonusId { get; set; }
    }
}