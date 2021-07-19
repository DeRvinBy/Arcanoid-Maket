namespace GamePacks.Data.Level.LevelParser
{
    public interface ILevelParser
    {
        LevelData ParseLevelData(string text);
    }
}