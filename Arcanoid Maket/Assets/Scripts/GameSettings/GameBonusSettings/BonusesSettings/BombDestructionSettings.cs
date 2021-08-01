using System.Linq;
using GameEntities.Blocks.Enumerations;
using UnityEngine;

namespace GameSettings.GameBonusSettings.BonusesSettings
{
    public class BombDestructionSettings : MonoBehaviour
    {
        [SerializeField]
        private float _blocksDestructionDelay = 0.2f;

        [SerializeField]
        private BlockType[] _destructionTypes;
        
        public float BlocksDestructionDelay => _blocksDestructionDelay;

        public bool IsBlockBelongDestructionType(BlockType type)
        {
            return _destructionTypes.Contains(type);
        }
    }
}