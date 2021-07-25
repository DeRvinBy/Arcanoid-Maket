using System.Collections.Generic;
using GameEntities.Blocks.Abstract;
using UnityEngine;

namespace GameComponents.Bonus.BonusesManagers.Bomb.Searchers
{
    public abstract class AbstractBlocksSearcher
    {
        protected Dictionary<int, List<AbstractBlock>> _destroyBlocksMap;
        protected Vector2Int _startCoords;
        protected AbstractBlock[,] _blocksMatrix;

        public void Setup(Vector2Int startCoords, AbstractBlock[,] blocksMatrix)
        {
            _startCoords = startCoords;
            _blocksMatrix = blocksMatrix;
        }

        protected bool IsWithinInMatrix(Vector2Int coords)
        {
            var isWithinX = coords.x >= 0 && coords.x <= _blocksMatrix.GetUpperBound(0);
            var isWithinY = coords.y >= 0 && coords.y <= _blocksMatrix.GetUpperBound(1);
            return isWithinX && isWithinY;
        }
        
        protected void AddBlockToDestroyMap(int level, AbstractBlock block)
        {
            if (!_destroyBlocksMap.ContainsKey(level))
            {
                _destroyBlocksMap.Add(level, new List<AbstractBlock>());
            }
            
            _destroyBlocksMap[level].Add(block);
        }
    }
}