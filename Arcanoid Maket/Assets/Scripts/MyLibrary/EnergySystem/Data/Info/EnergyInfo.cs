namespace MyLibrary.EnergySystem.Data.Info
{
    public class EnergyInfo
    {
        public int CurrentEnergy { get; }
        public int MaxEnergy { get; }
        public bool IsFullEnergy { get; }
        
        public EnergyInfo(int currentEnergy, int maxEnergy)
        {
            CurrentEnergy = currentEnergy;
            MaxEnergy = maxEnergy;
            IsFullEnergy = currentEnergy >= maxEnergy;
        }
    }
}