using System;
using GameEntities.Blocks.Enumerations;
using UnityEngine;

namespace GameSettings.GameBlockSettings
{
    [Serializable]
    public class VisualBlockSettingsContainer
    {
        [SerializeField]
        private BlockSpriteId _blockId = BlockSpriteId.Red;

        [SerializeField]
        private VisualBlockSettings _blockSettings;

        public BlockSpriteId BlockID => _blockId;
        public VisualBlockSettings BlockSettings => _blockSettings;
    }
}