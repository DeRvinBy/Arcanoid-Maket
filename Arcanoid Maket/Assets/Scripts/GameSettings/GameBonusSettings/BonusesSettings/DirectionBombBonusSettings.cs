using System.Collections.Generic;
using UnityEngine;

namespace GameSettings.GameBonusSettings.BonusesSettings
{
    public class DirectionBombBonusSettings : MonoBehaviour
    {
        [SerializeField]
        private float _blocksDestructionDelay = 0.2f;
        
        private readonly List<Vector2Int> _verticalMoveDirections = new List<Vector2Int>
        {
            new Vector2Int(0, 1), new Vector2Int(0, -1)
        };
        private readonly List<Vector2Int> _horizontalMoveDirections = new List<Vector2Int>
        {
            new Vector2Int(1, 0), new Vector2Int(-1, 0)
        };
        
        public float BlocksDestructionDelay => _blocksDestructionDelay;
        public List<Vector2Int> VerticalMoveDirections => _verticalMoveDirections;
        public List<Vector2Int> HorizontalMoveDirections => _horizontalMoveDirections;
    }
}