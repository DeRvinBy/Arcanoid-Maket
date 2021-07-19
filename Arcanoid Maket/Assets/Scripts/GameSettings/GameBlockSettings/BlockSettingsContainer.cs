using System;
using GameEntities.Blocks.Enumerations;
using UnityEngine;

namespace GameSettings.GameBlockSettings
{
    [Serializable]
    public class BlockSettingsContainer
    {
        [SerializeField]
        private BlockId _blockId = BlockId.Red;

        [SerializeField]
        private IndividualBlockSettings _blockSettings;

        public BlockId BlockID => _blockId;
        public IndividualBlockSettings BlockSettings => _blockSettings;
    }
}