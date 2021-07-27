namespace MyLibrary.EnergySystem.Data.Abstract
{
    public abstract class AbstractCommandWithEnergy
    {
        protected int _energyValue;
        protected EnergyService _service;

        public void Setup(EnergyService service, int energyValue)
        {
            _service = service;
            _energyValue = energyValue;
        }
        
        public abstract void Execute();
    }
}