namespace Scripts.GamePacks.Data.Player.SaveLoader
{
    public interface ISaveLoader
    {
        PacksSaveContainer Load();
        void Save(PacksSaveContainer container);
    }
}