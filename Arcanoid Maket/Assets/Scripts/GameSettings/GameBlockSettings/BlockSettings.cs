using System.Collections.Generic;
using GameEntities.Blocks.Enumerations;
using MyLibrary.ObjectPool.Abstract;
using UnityEngine;

namespace GameSettings.GameBlockSettings
{
    public class BlockSettings : AbstractSettings
    {
        [SerializeField]
        private BlockLifeSettings _lifeSettings;

        [SerializeField]
        private VisualBlockSettingsContainer[] _settingsContainers;

        public BlockLifeSettings LifeSettings => _lifeSettings;

        private Dictionary<BlockSpriteId, VisualBlockSettings> _settingsMap;

        public void Initialize()
        {
            _lifeSettings.Initialize();
            CreateSettingMap();
        }

        private void CreateSettingMap()
        {
            _settingsMap = new Dictionary<BlockSpriteId, VisualBlockSettings>();
            foreach (var container in _settingsContainers)
            {
                _settingsMap.Add(container.BlockID, container.BlockSettings);
            }
        }

        public VisualBlockSettings GetBlockSettings(BlockSpriteId blockID)
        {
            return _settingsMap[blockID];
        }
    }
}