using System.Collections.Generic;
using GameComponents.Blocks;
using GameEntities.Blocks.Abstract;
using UnityEngine;

namespace GameComponents.Bonus.BonusesManagers.Bomb.Searchers
{
    public abstract class AbstractBlocksSearcher
    {
        private readonly int _blockMatrixRows;
        private readonly int _blockMatrixColumns;
        private readonly GridBlocks _gridBlocks;

        protected readonly Vector2Int _startCoords;
        protected readonly AbstractBlock[,] _blocksMatrix;
        protected List<AbstractBlock> _destroyList;

        public AbstractBlocksSearcher(Vector2 bonusPosition, GridBlocks gridBlocks)
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

        public abstract bool IsHasNextBlocks();
        public abstract List<AbstractBlock> GetNextDestroyList();
        
        protected void AddBlockToDestroyList(AbstractBlock block)
        {
            _destroyList.Add(block);
            _gridBlocks.RemoveBlockFromMatrix(block);
        }
    }
}