using System.Collections.Generic;
using Project.Scripts.GameSettings.GameBlockSettings.Enumerations;
using UnityEngine;

namespace Project.Scripts.GameSettings.GameBlockSettings
{
    public class MainBlockSettings : MonoBehaviour
    {
        [SerializeField]
        private int blockLife = 3;

        [SerializeField]
        private BlockSettingsContainer[] _blockSettingsContainers;

        private Dictionary<BlockId, IndividualBlockSettings> _settingsMap;

        public int BlockLife => blockLife;

        private void Awake()
        {
            _settingsMap = new Dictionary<BlockId, IndividualBlockSettings>();

            foreach (var container in _blockSettingsContainers)
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