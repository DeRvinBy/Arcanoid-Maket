namespace GamePacks.Data.Player.SaveLoadManagers
{
    public interface IPacksSaveLoadManager
    {
        bool IsSaveExist();
        PacksSaveContainer LoadSave();
        void Save(PacksSaveContainer container);
    }
}