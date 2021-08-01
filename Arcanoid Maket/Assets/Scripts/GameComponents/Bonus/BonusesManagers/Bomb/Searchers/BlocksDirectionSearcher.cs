using System.Collections.Generic;
using System.Linq;
using GameComponents.Blocks;
using GameEntities.Bonuses.Enumerations;
using UnityEngine;

namespace GameComponents.Bonus.BonusesManagers.Bomb.Searchers
{
    public class BlocksDirectionSearcher : AbstractBlocksSearcher
    {
        private Dictionary<Vector2Int, Vector2Int> _moveCoordsMap;

        public BlocksDirectionSearcher(BombBonusDirection direction, Vector2 bonusPosition, GridBlocks gridBlocks) : base(bonusPosition, gridBlocks)
        {
            _moveCoordsMap = new Dictionary<Vector2Int, Vector2Int>();
            if (direction == BombBonusDirection.Horizontal)
            {
                _moveCoordsMap.Add(_startCoords + Vector2Int.right, Vector2Int.right);
                _moveCoordsMap.Add(_startCoords + Vector2Int.left, Vector2Int.left);
            }
            else
            {
                _moveCoordsMap.Add(_startCoords + Vector2Int.up, Vector2Int.up);
                _moveCoordsMap.Add(_startCoords + Vector2Int.down, Vector2Int.down);
            }
        }

        public override bool IsHasNextBlocks()
        {
            return _isHasNext;
        }

        protected override void FillDestroyBlocksList()
        {
            _isHasNext = false;
            var moves = _moveCoordsMap.ToList();
            _moveCoordsMap.Clear();
            
            foreach (var move in moves)
            {
                var coords = move.Key;
                if (IsWithinInMatrix(coords))
                {
                    _isHasNext = true;
                    var block = _blocksMatrix[coords.x, coords.y];
                    if (block != null)
                    {
                        AddBlockToDestroyList(block);
                    }

                    _moveCoordsMap.Add(coords + move.Value, move.Value);
                }
            }
        }
    }
}