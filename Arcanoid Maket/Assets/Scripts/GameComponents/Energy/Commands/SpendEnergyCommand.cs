using MyLibrary.EnergySystem.Data.Abstract;

namespace GameComponents.Energy.Commands
{
    public class SpendEnergyCommand : AbstractCommandWithEnergy
    {
        public override void Execute()
        {
            if (_service.IsEnoughEnergy(_energyValue))
            {
                _service.RemoveEnergy(_energyValue);
            }
        }
    }
}