using System.Collections.Generic;
using GameEntities.Blocks.Enumerations;
using GameSettings.GameBlockSettings.Destructible;
using GameSettings.GameBlockSettings.Indestructible;
using MyLibrary.ObjectPool.Abstract;
using UnityEngine;

namespace GameSettings.GameBlockSettings
{
    public class BlockSettings : AbstractSettings
    {
        [SerializeField]
        private BlockLifeSettings _lifeSettings;

        [SerializeField]
        private IndestructibleBlockSettings _indestructibleSettings;
        
        [SerializeField]
        private DestructibleBlockSettingsContainer[] _settingsContainers;

        public BlockLifeSettings LifeSettings => _lifeSettings;
        public IndestructibleBlockSettings IndestructibleSettings => _indestructibleSettings;

        private Dictionary<BlockId, DestructibleBlockSettings> _settingsMap;

        public void Initialize()
        {
            _lifeSettings.Initialize();
            CreateSettingMap();
        }

        private void CreateSettingMap()
        {
            _settingsMap = new Dictionary<BlockId, DestructibleBlockSettings>();
            foreach (var container in _settingsContainers)
            {
                _settingsMap.Add(container.BlockID, container.BlockSettings);
            }
        }

        public DestructibleBlockSettings GetBlockSettings(BlockId blockID)
        {
            return _settingsMap[blockID];
        }
    }
}