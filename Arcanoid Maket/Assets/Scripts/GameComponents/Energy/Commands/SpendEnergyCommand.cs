using MyLibrary.EnergySystem.Data.Abstract;

namespace GameComponents.Energy.Commands
{
    public class SpendEnergyCommand : AbstractCommandWithEnergy
    {
        public override void Execute()
        {
            _service.RemoveEnergy(_energyValue);
        }
    }
}