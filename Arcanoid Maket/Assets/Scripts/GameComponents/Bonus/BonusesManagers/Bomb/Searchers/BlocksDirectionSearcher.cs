using GameEntities.Blocks;
using GameEntities.Blocks.Abstract;
using UnityEngine;

namespace GameComponents.Bonus.BonusesManagers.Bomb.Searchers
{
    public class BlocksDirectionSearcher : AbstractBlocksSearcher
    {
        private int _level;

        public override void Setup(Vector2Int startCoords, AbstractBlock[,] blocksMatrix)
        {
            base.Setup(startCoords, blocksMatrix);
            _level = 1;
        }

        protected override void FillDestroyBlocksMap(Vector2Int direction)
        {
            var currentCoords = _startCoords + direction * _level;
            if (IsWithinInMatrix(currentCoords))
            {
                var block = _blocksMatrix[currentCoords.x, currentCoords.y];
                if (block != null && !(block is IndestructibleBlock))
                {
                    AddBlockToMap(_level, block);
                }

                _level++;
                FillDestroyBlocksMap(direction);
            }
        }
    }
}