namespace GamePacks.Data.Player.SaveLoadManagers
{
    public interface IPacksSaveLoadManager
    {
        bool IsSaveExist();
        PacksSaveContainer GetSave();
        void Save(PacksSaveContainer container);
    }
}