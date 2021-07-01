namespace Project.Scripts.MVC.GameField.Data.Level
{
    public class LevelData
    {
        public int HorizontalCount { get; private set; }
        public int VerticalCount { get; private set; }
        public int[,] Data { get; private set; }
        
        public LevelData(int verticalCount, int horizontalCount, int[,] data)
        {
            VerticalCount = verticalCount;
            HorizontalCount = horizontalCount;
            Data = data;
        }
    }
}