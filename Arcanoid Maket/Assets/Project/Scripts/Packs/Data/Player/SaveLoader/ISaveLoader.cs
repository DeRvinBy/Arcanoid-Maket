namespace Project.Scripts.Packs.Data.Player.SaveLoader
{
    public interface ISaveLoader
    {
        PacksSaveContainer Load();
        void Save(PacksSaveContainer container);
    }
}