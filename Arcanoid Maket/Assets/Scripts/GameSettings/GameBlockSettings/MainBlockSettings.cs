﻿using System.Collections.Generic;
using GameEntities.Blocks.Enumerations;
using Library.ObjectPool.Abstract;
using UnityEngine;

namespace GameSettings.GameBlockSettings
{
    public class MainBlockSettings : AbstractSettings
    {
        [SerializeField]
        private BlockLifeSettings _lifeSettings;
        
        [SerializeField]
        private BlockSettingsContainer[] _settingsContainers;

        public BlockLifeSettings LifeSettings => _lifeSettings;
        
        private Dictionary<BlockId, IndividualBlockSettings> _settingsMap;

        public void Initialize()
        {
            _lifeSettings.Initialize();
            CreateSettingMap();
        }

        private void CreateSettingMap()
        {
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