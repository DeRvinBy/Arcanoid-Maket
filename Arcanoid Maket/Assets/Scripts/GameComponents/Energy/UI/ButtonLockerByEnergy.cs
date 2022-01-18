using GameComponents.Energy.Commands;
using GameComponents.Energy.Enumerations;
using MyLibrary.EnergySystem;
using MyLibrary.EnergySystem.Interfaces;
using MyLibrary.EventSystem;
using MyLibrary.UI.Button;
using MyLibrary.UI.Popup;
using TMPro;
using UI.Popups;
using UnityEngine;
using UnityEngine.UI;

namespace GameComponents.Energy.UI
{
    public class ButtonLockerByEnergy : MonoBehaviour, IEnergyUpdatedHandler
    {
        [SerializeField]
        private TypeActionForEnergy _typeAction;

        [SerializeField]
        private Image _imageLocker;

        [SerializeField]
        private TMP_Text _lockerText;

        [SerializeField] 
        private EventButton _lockerButton;
        
        private bool _isUpdate;
        private ButtonLockerCommand _command;

        private void Awake()
        {
            _command = new ButtonLockerCommand(_imageLocker, _lockerText);
            EnergyManager.Instance.SetupCommandWithEnergy(_command, (int)_typeAction);
            _lockerButton.OnButtonPressed += OnLockerButtonPressed;
        }

        private void OnEnable()
        {
            _isUpdate = true;
            EventBus.Subscribe(this);
            OnEnergyUpdated();
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(this);
            _isUpdate = false;
        }

        private void OnLockerButtonPressed()
        {
            StartCoroutine(PopupsController.Instance.ShowPopup<RewardedEnergyPopup>());
        }

        public void SetLockerUpdate(bool isUpdate)
        {
            _isUpdate = isUpdate;
        }

        public void OnEnergyUpdated()
        {
            if (_isUpdate)
            {
                _command.Execute();
            }
        }
    }
}