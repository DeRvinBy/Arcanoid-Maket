using GameEntities.Blocks.Enumerations;
using GameEntities.Bonuses.Enumerations;

namespace GameEntities.Blocks.Data
{
    public class BlockProperties
    {
        public BlockType Type { get; set; }
        public BlockSpriteId SpriteId { get; set; }
        public BonusType BonusId { get; set; }
    }
}