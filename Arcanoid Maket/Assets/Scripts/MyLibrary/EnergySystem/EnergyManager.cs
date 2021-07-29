using System;
using GameComponents.Energy.Commands;
using MyLibrary.EnergySystem.Data;
using MyLibrary.EnergySystem.Data.Abstract;
using MyLibrary.EnergySystem.Data.Config;
using MyLibrary.EnergySystem.Data.EnergySave;
using MyLibrary.EnergySystem.Data.EnergySave.Interfaces;
using MyLibrary.EnergySystem.Data.Info;
using MyLibrary.EnergySystem.Interfaces;
using MyLibrary.EventSystem;
using MyLibrary.Singleton;
using UnityEngine;

namespace MyLibrary.EnergySystem
{
    public class EnergyManager : Singleton<EnergyManager>
    {
        private const string ConfigPath = "Data/energyConfig";

        private IEnergySaveLoadManager _saveLoadManager;
        private EnergySaveItem _energySave;
        private EnergyConfig _config;
        private EnergyService _service;
        private EnergyRestore _restore;

        protected override void OnApplicationQuit()
        {
            SaveEnergy();
        }
        
        private void OnApplicationPause(bool pauseStatus)
        {
            SaveEnergy();
        }
        
        private void SaveEnergy()
        {
            var energyInfo = _service.GetEnergyInfo();
            _energySave.EnergySaveValue = energyInfo.CurrentEnergy;
            _energySave.RestoreProgress = _restore.GetRestoreProgress();
            _energySave.TimeSaveValue = DateTime.Now;
            _saveLoadManager.SaveEnergySave(_energySave);
        }

        protected override void Initialize()
        {
            _config = Resources.Load<EnergyConfig>(ConfigPath);
            _saveLoadManager = new PlayerPrefsEnergySaveLoadManager();
            LoadEnergy();
            
            _service = new EnergyService();
            _service.Initialize(_config, _energySave.EnergySaveValue);

            _restore = gameObject.AddComponent<EnergyRestore>();
            _restore.Initialize(_config);
            if (!_service.IsFullEnergy())
            {
                var offlineEnergy = _restore.GetEnergyStoredOffline(_energySave);
                _service.AddEnergy(offlineEnergy);
            }

            _service.OnEnergyChanged += UpdateCurrentEnergy;
            _restore.OnEnergyRestoreCompleted += RestoreEnergy;
            UpdateCurrentEnergy();
        }

        private void LoadEnergy()
        {
            if (_saveLoadManager.IsSaveExist())
            {
                _energySave = _saveLoadManager.LoadEnergySave();
            }
            else
            {
                _energySave = new EnergySaveItem {EnergySaveValue = _config.MaxEnergy, TimeSaveValue = DateTime.Now};
            }
        }

        private void UpdateCurrentEnergy()
        {
            EventBus.RaiseEvent<IEnergyUpdatedHandler>(a => a.OnEnergyUpdated());
            if (!_service.IsFullEnergy())
            {
                _restore.StartRestoreEnergy();
            }
            else
            {
                _restore.StopRestoreEnergy();
            }
        }

        private void RestoreEnergy()
        {
            _service.AddEnergy(_config.EnergyPerTime);
        }

        public EnergyInfo GetEnergyInfo()
        {
            return _service.GetEnergyInfo();
        }
        
        public TimeSpan GetCurrentRestoreInterval()
        {
            return _restore.GetCurrentRestoreInterval();
        }
        
        public void SetupCommandWithEnergy(AbstractCommandWithEnergy abstractCommand, int energyValueId)
        {
            var value = _config.EnergyValuesContainer.GetCostById(energyValueId);
            abstractCommand.Setup(_service, value);
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                _service.AddEnergyOverLimit(5);
            }
            
            if (Input.GetKeyDown(KeyCode.S))
            {
                _service.RemoveEnergy(5);
            }
        }
    }
}