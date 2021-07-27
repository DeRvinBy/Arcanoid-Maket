using MyLibrary.EnergySystem.Data.Abstract;
using MyLibrary.UI.Button;

namespace GameComponents.Energy.Commands
{
    public class ButtonEnableByEnergyCommand : AbstractCommandWithEnergy
    {
        private EventButton _button;
        
        public ButtonEnableByEnergyCommand(EventButton button)
        {
            _button = button;
        }
        
        public override void Execute()
        {
            if (_service.IsEnoughEnergy(_energyValue))
            {
                _button.Enable();
            }
            else
            {
                _button.Disable();
            }
        }
    }
}