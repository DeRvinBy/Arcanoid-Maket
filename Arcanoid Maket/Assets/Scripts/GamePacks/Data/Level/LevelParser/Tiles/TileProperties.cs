using MyLibrary.Prototype;

namespace GamePacks.Data.Level.LevelParser.Tiles
{
    public class TileProperties : IPrototype<TileProperties>
    {
        public int TypeId { get; set; }
        public int SpriteId { get; set; }
        public int BonusId { get; set; }
        
        public TileProperties GetCopy()
        {
            return (TileProperties)this.MemberwiseClone();
        }
    }
}