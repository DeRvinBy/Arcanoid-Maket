namespace GamePacks.Data.Player.SaveLoadManagers
{
    public interface IPacksSaveLoadManager
    {
        bool IsSaveExist();
        PacksSaveContainer Load();
        void Save(PacksSaveContainer container);
    }
}