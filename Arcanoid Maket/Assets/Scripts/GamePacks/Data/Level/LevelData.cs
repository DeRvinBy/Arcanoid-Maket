namespace Scripts.GamePacks.Data.Level
{
    public class LevelData
    {
        public int HorizontalCount { get; }
        public int VerticalCount { get; }
        public int[,] Data { get; }
        
        public LevelData(int verticalCount, int horizontalCount, int[,] data)
        {
            VerticalCount = verticalCount;
            HorizontalCount = horizontalCount;
            Data = data;
        }
    }
}