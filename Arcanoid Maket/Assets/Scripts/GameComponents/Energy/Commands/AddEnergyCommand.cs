using MyLibrary.EnergySystem.Data.Abstract;
using UnityEngine;

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