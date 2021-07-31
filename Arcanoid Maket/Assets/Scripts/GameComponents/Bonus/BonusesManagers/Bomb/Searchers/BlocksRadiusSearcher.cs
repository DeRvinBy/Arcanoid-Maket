using System.Collections.Generic;
using GameComponents.Blocks;
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
        
        public BlocksRadiusSearcher(Vector2 bonusPosition, GridBlocks gridBlocks) 
            : base(bonusPosition, gridBlocks) { }

        public override bool IsHasNextBlocks()
        {
            return false;
        }

        public override List<AbstractBlock> GetNextDestroyList()
        {
            _destroyList = new List<AbstractBlock>();
            FillDestroyBlocksList();
            return _destroyList;
        }
        
        private void FillDestroyBlocksList()
        {
            foreach (var direction in _moveDirections)
            {
                var currentCoords = _startCoords + direction;
                if (IsWithinInMatrix(currentCoords))
                {
                    var block = _blocksMatrix[currentCoords.x, currentCoords.y];
                    if (block != null)
                    {
                        AddBlockToDestroyList(block);
                    }
                }
            }
        }
    }
}