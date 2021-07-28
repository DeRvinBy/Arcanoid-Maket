using System;
using System.Collections;
using MyLibrary.EnergySystem.Data.Config;
using MyLibrary.EnergySystem.Data.EnergySave;
using UnityEngine;

namespace MyLibrary.EnergySystem.Data
{
    public class EnergyRestore : MonoBehaviour
    {
        public event Action OnEnergyRestoreCompleted;
        
        private EnergyConfig _config;
        private DateTime _nextRestoreTime;
        private bool _isRestoring;

        public void Initialize(EnergyConfig config)
        {
            _config = config;
        }
        
        public int GetEnergyStoredOffline(EnergySaveItem energySave)
        {
            var now = DateTime.Now;
            var timeInterval = now.Subtract(energySave.TimeSaveValue);
            var passedTime = timeInterval.TotalSeconds + energySave.RestoreProgress * _config.RestoringTimeInSeconds;
            var energy = _config.EnergyPerTime * (int) passedTime / _config.RestoringTimeInSeconds;

            return (int)energy;
        }

        public float GetRestoreProgress()
        {
            if (_isRestoring)
            {
                var remainingSeconds = (float)_nextRestoreTime.Subtract(DateTime.Now).TotalSeconds;
                return remainingSeconds / _config.RestoringTimeInSeconds;
            }

            return 0;
        }

        public void StartRestoreEnergy()
        {
            if (_isRestoring) return;
            _isRestoring = true;
            StartCoroutine(RestoreEnergy());
        }
        
        public void StopRestoreEnergy()
        {
            StopAllCoroutines();
            _isRestoring = false;
        }
        
        private IEnumerator RestoreEnergy()
        {
            var restoreInterval = _config.RestoringTimeInSeconds;
            _nextRestoreTime = DateTime.Now.AddSeconds(restoreInterval);

            var currentTime = 0f;
            while (currentTime < restoreInterval)
            {
                yield return new WaitForSeconds(1f);
                currentTime += 1f;
            }
            
            _isRestoring = false;
            OnEnergyRestoreCompleted?.Invoke();
        }
        
        public TimeSpan GetCurrentRestoreInterval()
        {
            return _nextRestoreTime.Subtract(DateTime.Now);
        }
    }
}