namespace MyLibrary.Energy.Data.EnergySave.Interfaces
{
    public interface IEnergySaveLoadManager
    {
        bool IsSaveExist();
        EnergySaveItem LoadEnergySave();
        void SaveEnergySave(EnergySaveItem save);
    }
}