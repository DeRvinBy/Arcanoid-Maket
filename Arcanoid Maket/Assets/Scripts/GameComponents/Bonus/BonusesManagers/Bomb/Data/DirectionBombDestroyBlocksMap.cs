using System.Collections.Generic;
using GameEntities.Blocks;
using GameEntities.Blocks.Abstract;
using UnityEngine;

namespace GameComponents.Bonus.BonusesManagers.Bomb.Data
{
    public class DirectionBombDestroyBlocksMap
    {
        public Dictionary<int, List<AbstractBlock>> DestroyBlocksMap { get; }
        private readonly Vector2Int _startCoords;
        private readonly AbstractBlock[,] _blocksMatrix;
        
        public DirectionBombDestroyBlocksMap(Vector2Int startCoords, AbstractBlock[,] blocksMatrix)
        {
            DestroyBlocksMap = new Dictionary<int, List<AbstractBlock>>();
            _startCoords = startCoords;
            _blocksMatrix = blocksMatrix;
        }

        public void FillDestroyBlocksMap(int level, Vector2Int moveDirection)
        {
            var currentCoords = _startCoords + moveDirection * level;
            var isWithinX = currentCoords.x >= 0 && currentCoords.x <= _blocksMatrix.GetUpperBound(0);
            var isWithinY = currentCoords.y >= 0 && currentCoords.y <= _blocksMatrix.GetUpperBound(1);
            if (isWithinX && isWithinY)
            {
                var block = _blocksMatrix[currentCoords.x, currentCoords.y];
                if (block != null && !(block is IndestructibleBlock))
                {
                    AddBlockToMap(level, block);
                }
                FillDestroyBlocksMap(++level, moveDirection);
            }
        }
        
        private void AddBlockToMap(int level, AbstractBlock block)
        {
            if (!DestroyBlocksMap.ContainsKey(level))
            {
                DestroyBlocksMap.Add(level, new List<AbstractBlock>());
            }   
            
            DestroyBlocksMap[level].Add(block);
        }
    }
}