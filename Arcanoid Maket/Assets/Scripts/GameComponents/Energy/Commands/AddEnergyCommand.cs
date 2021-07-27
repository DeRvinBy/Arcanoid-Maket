using MyLibrary.EnergySystem.Data.Abstract;

namespace GameComponents.Energy.Commands
{
    public class AddEnergyCommand : AbstractCommandWithEnergy
    {
        public override void Execute()
        {
            _service.AddEnergyOverLimit(_energyValue);
        }
    }
}