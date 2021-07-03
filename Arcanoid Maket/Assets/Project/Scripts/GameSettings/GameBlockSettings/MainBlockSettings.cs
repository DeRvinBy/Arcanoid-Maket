using System.Collections.Generic;
using Project.Scripts.MVC.Blocks.Enumerations;
using UnityEngine;

namespace Project.Scripts.GameSettings.GameBlockSettings
{
    public class MainBlockSettings : MonoBehaviour
    {
        [SerializeField]
        private BlockLifeSettings _lifeSettings = null;
        
        [SerializeField]
        private BlockSettingsContainer[] _settingsContainers;

        public BlockLifeSettings LifeSettings => _lifeSettings;
        
        private Dictionary<BlockId, IndividualBlockSettings> _settingsMap;

        private void Awake()
        {
            _lifeSettings.Initialize();
            _settingsMap = new Dictionary<BlockId, IndividualBlockSettings>();

            foreach (var container in _settingsContainers)
            {
                _settingsMap.Add(container.BlockID, container.BlockSettings);
            }
        }

        public IndividualBlockSettings GetBlockSettings(BlockId blockID)
        {
            return _settingsMap[blockID];
        }
    }
}