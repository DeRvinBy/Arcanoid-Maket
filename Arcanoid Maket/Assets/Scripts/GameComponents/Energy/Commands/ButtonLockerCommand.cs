using MyLibrary.EnergySystem.Data.Abstract;
using MyLibrary.Extensions;
using TMPro;
using UnityEngine.UI;

namespace GameComponents.Energy.Commands
{
    public class ButtonLockerCommand : AbstractCommandWithEnergy
    {
        private Image _imageLocker;
        private TMP_Text _textLocker;
        
        public ButtonLockerCommand(Image imageLocker, TMP_Text textLocker)
        {
            _imageLocker = imageLocker;
            _textLocker = textLocker;
        }
        
        public override void Execute()
        {
            if (_service.IsEnoughEnergy(_energyValue))
            {
                _imageLocker.SetActive(false);
            }
            else
            {
                _imageLocker.SetActive(true);
                _textLocker.text = _energyValue.ToString();
            }
        }
    }
}