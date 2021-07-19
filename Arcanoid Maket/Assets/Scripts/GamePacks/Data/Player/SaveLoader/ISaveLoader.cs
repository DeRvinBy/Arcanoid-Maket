namespace Scripts.GamePacks.Data.Player.SaveLoader
{
    public interface ISaveLoader
    {
        bool IsSaveExist();
        PacksSaveContainer Load();
        void Save(PacksSaveContainer container);
    }
}