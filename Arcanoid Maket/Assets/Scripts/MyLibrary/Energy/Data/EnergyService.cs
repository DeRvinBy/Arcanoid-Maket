using System;
using MyLibrary.Energy.Data.Config;
using MyLibrary.Energy.Data.EnergySave;
using MyLibrary.Energy.Data.EnergySave.Interfaces;
using UnityEngine;

namespace MyLibrary.Energy.Data
{
    public class EnergyService
    {
        private IEnergySaveLoadManager _saveLoadManager;
        private EnergyConfig _config;
        private EnergySaveItem _energySave;

        public EnergyService(IEnergySaveLoadManager saveLoadManager)
        {
            _saveLoadManager = saveLoadManager;
        }
        
        public void SaveEnergy()
        {
            _saveLoadManager.SaveEnergySave(_energySave);
        }
        
        public void Initialize(EnergyConfig config)
        {
            _config = config;
            _energySave = _saveLoadManager.LoadEnergySave();
            UpdateEnergySaveByCurrentTime();
        }

        private void UpdateEnergySaveByCurrentTime()
        {
            var now = DateTime.Now.AddMonths(1);
            var timeInterval = now.Subtract(_energySave.TimeSaveValue);
            Debug.Log("Total minutes: " + timeInterval.TotalMinutes);
            var energy = _config.EnergyPerTime * (int)(timeInterval.TotalMinutes / _config.RestoringTimeInMinutes);
            AddEnergy(energy);
            Debug.Log("Current energy: " + _energySave.EnergySaveValue);
        }

        private void AddEnergy(int value)
        {
            Debug.Log("Add value: " + value);
            _energySave.EnergySaveValue += value;
            if (_energySave.EnergySaveValue > _config.MaxEnergy)
            {
                _energySave.EnergySaveValue = _config.MaxEnergy;
            }
        }
    }
}