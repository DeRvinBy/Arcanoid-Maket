namespace Project.Scripts.Packs.Data.Level.LevelParser
{
    public interface ILevelParser
    {
        LevelData ParseLevelData(string text);
    }
}