using System.Collections.Generic;
using GameEntities.Blocks.Abstract;
using UnityEngine;

namespace GameComponents.Bonus.BonusesManagers.Bomb.Searchers
{
    public class BlocksRadiusSearcher : AbstractBlocksSearcher
    {
        private readonly List<Vector2Int> _moveDirections = new List<Vector2Int>
        {
            new Vector2Int(-1, 1), Vector2Int.up, new Vector2Int(1, 1),
            Vector2Int.left, Vector2Int.right,
            new Vector2Int(-1, -1), Vector2Int.down, new Vector2Int(1, -1)
        };
        
        public Dictionary<int, List<AbstractBlock>> GetDestroyBlocksMap()
        {
            _destroyBlocksMap = new Dictionary<int, List<AbstractBlock>>();
            foreach (var direction in _moveDirections)
            {
                FillDestroyBlocksMap(direction);
            }

            return _destroyBlocksMap;
        }
        
        private void FillDestroyBlocksMap(Vector2Int direction)
        {
            var currentCoords = _startCoords + direction;
            if (IsWithinInMatrix(currentCoords))
            {
                var block = _blocksMatrix[currentCoords.x, currentCoords.y];
                if (block != null)
                {
                    AddBlockToDestroyMap(0, block);
                }
            }
        }
    }
}