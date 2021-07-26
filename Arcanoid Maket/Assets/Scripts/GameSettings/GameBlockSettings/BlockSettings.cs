using System.Collections.Generic;
using GameEntities.Blocks.Enumerations;
using GameSettings.GameBonusSettings.ObjectSettings;
using MyLibrary.ObjectPool.Abstract;
using UnityEngine;

namespace GameSettings.GameBlockSettings
{
    [CreateAssetMenu(fileName = "New Block Settings", menuName = "Creator Settings/Block Settings")]
    public class BlockSettings : AbstractSettings
    {
        [SerializeField]
        private BlockLifeSettings _lifeSettings;

        [SerializeField]
        private VisualBlockSettingsContainer[] _visualSettingsContainers;

        [SerializeField]
        private BonusObjectSettings _bonusObjectSettings;
        
        public BlockLifeSettings LifeSettings => _lifeSettings;
        public BonusObjectSettings BonusObjectSettings => _bonusObjectSettings;

        private Dictionary<BlockSpriteId, VisualBlockSettings> _settingsMap;

        public void Initialize()
        {
            _lifeSettings.Initialize();
            CreateSettingMaps();
        }

        private void CreateSettingMaps()
        {
            _settingsMap = new Dictionary<BlockSpriteId, VisualBlockSettings>();
            foreach (var container in _visualSettingsContainers)
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