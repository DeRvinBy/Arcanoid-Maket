using System;
using System.Collections;
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
        private bool _isRestoring;

        private DateTime _nextRestoreTime;
        
        public EnergyService(IEnergySaveLoadManager saveLoadManager)
        {
            _saveLoadManager = saveLoadManager;
        }
        
        public void SaveEnergy()
        {
            if (_isRestoring)
            {
                var remainingSeconds = (float)_nextRestoreTime.Subtract(DateTime.Now).TotalSeconds;
                _energySave.RestoreProgress = remainingSeconds / _config.RestoringTimeInSeconds;
            }
            else
            {
                _energySave.RestoreProgress = 0;
            }
            _energySave.TimeSaveValue = DateTime.Now;
            _saveLoadManager.SaveEnergySave(_energySave);
        }
        
        public void Initialize(EnergyConfig config)
        {
            _config = config;
            
            if (_saveLoadManager.IsSaveExist())
            {
                _energySave = _saveLoadManager.LoadEnergySave();
                UpdateEnergySaveByCurrentTime();
            }
            else
            {
                _energySave = new EnergySaveItem {EnergySaveValue = 30, TimeSaveValue = DateTime.Now};
                UpdateNextRestoreTime(_config.RestoringTimeInSeconds);
            }
        }

        private void UpdateEnergySaveByCurrentTime()
        {
            var now = DateTime.Now;
            var timeInterval = now.Subtract(_energySave.TimeSaveValue);
            
            var passedTime = timeInterval.TotalSeconds + _energySave.RestoreProgress * _config.RestoringTimeInSeconds;
            var energy = _config.EnergyPerTime * (int) passedTime / _config.RestoringTimeInSeconds;
            var remainingSeconds = (int) passedTime % _config.RestoringTimeInSeconds;
            AddEnergy(energy);
            UpdateNextRestoreTime(remainingSeconds);
        }

        private void UpdateNextRestoreTime(int seconds)
        {
            _nextRestoreTime = DateTime.Now.AddSeconds(seconds);
        }

        private void AddEnergy(int value)
        {
            _energySave.EnergySaveValue += value;
            if (_energySave.EnergySaveValue > _config.MaxEnergy)
            {
                _energySave.EnergySaveValue = _config.MaxEnergy;
                _isRestoring = false;
            }
        }

        public IEnumerator RestoreEnergy()
        {
            if (_energySave.EnergySaveValue < _config.MaxEnergy)
            {
                _isRestoring = true;
            }

            do
            {
                var restoreInterval = (float)_nextRestoreTime.Subtract(DateTime.Now).TotalSeconds;
                if (restoreInterval <= 0 || restoreInterval > _config.RestoringTimeInSeconds)
                {
                    restoreInterval = _config.RestoringTimeInSeconds;
                    _nextRestoreTime = DateTime.Now.AddSeconds(restoreInterval);
                }
                yield return new WaitForSeconds(restoreInterval);
                AddEnergy(_config.EnergyPerTime);
                UpdateNextRestoreTime(_config.RestoringTimeInSeconds);
            } 
            while (_isRestoring);
        }
    }
}