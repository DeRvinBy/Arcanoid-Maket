using System.Collections.Generic;
using GameComponents.Blocks;
using GameEntities.Blocks.Abstract;
using UnityEngine;

namespace GameComponents.Bonus.BonusesManagers.Bomb.Searchers
{
    public abstract class AbstractBlocksSearcher
    {
        private int _blockMatrixRows;
        private int _blockMatrixColumns;
        private GridBlocks _gridBlocks;

        protected Vector2Int _startCoords;
        protected AbstractBlock[,] _blocksMatrix;
        protected Dictionary<int, List<AbstractBlock>> _destroyBlocksMap;

        public void Setup(Vector2 bonusPosition, GridBlocks gridBlocks)
        {
            _gridBlocks = gridBlocks;
            _startCoords = _gridBlocks.GetBlocksCoordinates(bonusPosition);
            _blocksMatrix = _gridBlocks.GetBlocksMatrix();
            var matrix = _gridBlocks.GetBlocksMatrix();
            _blockMatrixRows = matrix.GetUpperBound(0);
            _blockMatrixColumns = matrix.GetUpperBound(1);
        }

        protected bool IsWithinInMatrix(Vector2Int coords)
        {
            var isWithinX = coords.x >= 0 && coords.x <= _blockMatrixRows;
            var isWithinY = coords.y >= 0 && coords.y <= _blockMatrixColumns;
            return isWithinX && isWithinY;
        }

        public abstract Dictionary<int, List<AbstractBlock>> GetDestroyBlocksMap();
        
        protected void AddBlockToDestroyMap(int level, AbstractBlock block)
        {
            if (!_destroyBlocksMap.ContainsKey(level))
            {
                _destroyBlocksMap.Add(level, new List<AbstractBlock>());
            }
            
            _destroyBlocksMap[level].Add(block);
            _gridBlocks.RemoveBlockFromMatrix(block);
        }
    }
}