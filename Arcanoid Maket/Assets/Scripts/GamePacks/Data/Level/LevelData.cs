using GamePacks.Data.Level.LevelParser.Tiles;

namespace GamePacks.Data.Level
{
    public class LevelData
    {
        public int HorizontalCount { get; }
        public int VerticalCount { get; }
        public TileProperties[,] Data { get; }
        
        public LevelData(int verticalCount, int horizontalCount, TileProperties[,] data)
        {
            VerticalCount = verticalCount;
            HorizontalCount = horizontalCount;
            Data = data;
        }
    }
}