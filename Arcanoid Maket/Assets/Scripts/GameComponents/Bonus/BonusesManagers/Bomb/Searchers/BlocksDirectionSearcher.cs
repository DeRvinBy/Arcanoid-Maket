﻿using System.Collections.Generic;
using GameEntities.Blocks;
using GameEntities.Blocks.Abstract;
using GameEntities.Bonuses.Enumerations;
using UnityEngine;

namespace GameComponents.Bonus.BonusesManagers.Bomb.Searchers
{
    public class BlocksDirectionSearcher : AbstractBlocksSearcher
    {
        public Dictionary<int, List<AbstractBlock>> GetDestroyBlocksMap(BombBonusDirection direction)
        {
            _destroyBlocksMap = new Dictionary<int, List<AbstractBlock>>();
            
            if (direction == BombBonusDirection.Horizontal)
            {
                FillDestroyBlocksMap(1, Vector2Int.left);
                FillDestroyBlocksMap(1, Vector2Int.right);
            }
            else
            {
                FillDestroyBlocksMap(1, Vector2Int.up);
                FillDestroyBlocksMap(1, Vector2Int.down);
            }
            
            return _destroyBlocksMap;
        }
        
        private void FillDestroyBlocksMap(int level, Vector2Int direction)
        {
            var currentCoords = _startCoords + direction * level;
            if (IsWithinInMatrix(currentCoords))
            {
                var block = _blocksMatrix[currentCoords.x, currentCoords.y];
                if (block != null && !(block is IndestructibleBlock))
                {
                    AddBlockToDestroyMap(level, block);
                }
                
                FillDestroyBlocksMap(++level, direction);
            }
        }
    }
}