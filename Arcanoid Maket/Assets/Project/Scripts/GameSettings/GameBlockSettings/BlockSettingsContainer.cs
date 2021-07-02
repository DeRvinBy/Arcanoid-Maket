using System;
using Project.Scripts.GameSettings.GameBlockSettings.Enumerations;
using UnityEngine;

namespace Project.Scripts.GameSettings.GameBlockSettings
{
    [Serializable]
    public class BlockSettingsContainer
    {
        [SerializeField]
        private BlockId _blockId = BlockId.Red;

        [SerializeField]
        private IndividualBlockSettings _blockSettings = null;

        public BlockId BlockID => _blockId;

        public IndividualBlockSettings BlockSettings => _blockSettings;
    }
}