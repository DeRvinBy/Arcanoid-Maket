using System;
using GameEntities.Blocks.Enumerations;
using UnityEngine;

namespace GameSettings.GameBlockSettings
{
    [Serializable]
    public class DestructibleBlockSettingsContainer
    {
        [SerializeField]
        private BlockId _blockId = BlockId.Red;

        [SerializeField]
        private DestructibleBlockSettings _blockSettings;

        public BlockId BlockID => _blockId;
        public DestructibleBlockSettings BlockSettings => _blockSettings;
    }
}