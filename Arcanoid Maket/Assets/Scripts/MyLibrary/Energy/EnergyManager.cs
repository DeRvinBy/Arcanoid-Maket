using MyLibrary.Energy.Data;
using MyLibrary.Energy.Data.Config;
using MyLibrary.Energy.Data.EnergySave;
using MyLibrary.Singleton;
using UnityEngine;

namespace MyLibrary.Energy
{
    public class EnergyManager : Singleton<EnergyManager>
    {
        private const string ConfigPath = "Data/energyConfig";
        
        private EnergyService _service;

        private void OnApplicationPause(bool pauseStatus)
        {
            _service.SaveEnergy();
        }

        protected override void Initialize()
        {
            base.Initialize();
            var saveLoadManager = new PlayerPrefsEnergySaveLoadManager();
            _service = new EnergyService(saveLoadManager);
            var config = Resources.Load<EnergyConfig>(ConfigPath);
            _service.Initialize(config);

            StartCoroutine(_service.RestoreEnergy());
        }
    }
}