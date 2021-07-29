using MyLibrary.EnergySystem.Interfaces;
using MyLibrary.EventSystem;
using MyLibrary.Extensions;
using TMPro;
using UnityEngine;

namespace MyLibrary.EnergySystem.UI
{
    public class UIEnergyElement : MonoBehaviour, IEnergyUpdatedHandler
    {
        [SerializeField]
        private TMP_Text _energyInfoText;

        [SerializeField]
        private string _energyInfoFormat = "{0}/{1}";
        
        [SerializeField]
        private TMP_Text _timerToNextEnergyText;
        
        [SerializeField]
        private string _timerToNextEnergyFormat = "{0:d2}:{1:d2}";

        private bool _isUpdateTimer;
        
        private void OnEnable()
        {
            EventBus.Subscribe(this);
            OnEnergyUpdated();
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(this);
        }

        private void Update()
        {
            if (_isUpdateTimer)
            {
                var interval = EnergyManager.Instance.GetCurrentRestoreInterval();
                var intervalText = string.Format(_timerToNextEnergyFormat, interval.Minutes, interval.Seconds);
                _timerToNextEnergyText.text = intervalText;
            }
        }

        public void OnEnergyUpdated()
        {
            var info = EnergyManager.Instance.GetEnergyInfo();
            var energyText = string.Format(_energyInfoFormat, info.CurrentEnergy, info.MaxEnergy);
            _energyInfoText.text = energyText;

            _isUpdateTimer = !info.IsFullEnergy;
            _timerToNextEnergyText.SetActive(_isUpdateTimer);
        }
    }
}