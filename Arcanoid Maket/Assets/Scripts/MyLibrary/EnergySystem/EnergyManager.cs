using MyLibrary.EnergySystem.Data;
using MyLibrary.EnergySystem.Data.Abstract;
using MyLibrary.EnergySystem.Data.Config;
using MyLibrary.EnergySystem.Data.EnergySave;
using MyLibrary.Singleton;
using UnityEngine;

namespace MyLibrary.EnergySystem
{
    public class EnergyManager : Singleton<EnergyManager>
    {
        private const string ConfigPath = "Data/energyConfig";

        private EnergyService _service;
        private EnergyValuesContainer _energyValues;

        private void OnApplicationPause(bool pauseStatus)
        {
            _service.SaveEnergy();
        }

        protected override void Initialize()
        {
            var saveLoadManager = new PlayerPrefsEnergySaveLoadManager();
            _service = new EnergyService(saveLoadManager);
            var config = Resources.Load<EnergyConfig>(ConfigPath);
            _service.Initialize(config);
            _energyValues = config.EnergyValuesContainer;

            StartCoroutine(_service.RestoreEnergy());
        }

        public void SetupCommand(AbstractCommandWithEnergy abstractCommand, int energyValueId)
        {
            var value = _energyValues.GetCostById(energyValueId);
            abstractCommand.Setup(_service, value);
        }
    }
}