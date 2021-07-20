namespace GamePacks.Data.Level.LevelParser.Interfaces
{
    public interface ILevelParser
    {
        LevelData ParseLevelData(string text);
    }
}