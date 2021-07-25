using System.Collections.Generic;
using GameEntities.Blocks;
using GameEntities.Blocks.Abstract;
using GameEntities.Blocks.Enumerations;
using UnityEngine;

namespace GameComponents.Bonus.BonusesManagers.Bomb.Searchers
{
    public class BlocksColorSearcher : AbstractBlocksSearcher
    {
        private readonly List<Vector2Int> _moveDirections = new List<Vector2Int>
        {
            Vector2Int.left, 
            Vector2Int.up, 
            Vector2Int.right, 
            Vector2Int.down
        };
        private Dictionary<BlockSpriteId, HashSet<ColorBlock>> _colorBlocksMap;
        private Dictionary<ColorBlock, Vector2Int> _blockCoordsMap;
        private List<Vector2Int> _passedCoords;

        public Dictionary<int, List<AbstractBlock>> GetDestroyBlocksMap()
        {
            _colorBlocksMap = new Dictionary<BlockSpriteId, HashSet<ColorBlock>>();
            _blockCoordsMap = new Dictionary<ColorBlock, Vector2Int>();
            _passedCoords = new List<Vector2Int>();
            _destroyBlocksMap = new Dictionary<int, List<AbstractBlock>>();
            FindColorBlocks();
            FillDestroyMap();
            return _destroyBlocksMap;
        }

        private void FindColorBlocks()
        {
            foreach (var direction in _moveDirections)
            {
                var currentCoords = _startCoords + direction;
                if (IsWithinInMatrix(currentCoords))
                {
                    _passedCoords.Add(currentCoords);
                    
                    var block = _blocksMatrix[currentCoords.x, currentCoords.y];
                    if (block != null && block is ColorBlock colorBlock)
                    {
                        AddBlockToColorBlocksMap(colorBlock);
                        AddBlockToBlockCoordsMap(colorBlock, currentCoords);
                        FindBlocksByColor(colorBlock.BlockColor, currentCoords);
                    }
                }
            }
        }
        
        private void FindBlocksByColor(BlockSpriteId color, Vector2Int coords)
        {
            foreach (var direction in _moveDirections)
            {
                var currentCoords = coords + direction;
                if (IsWithinInMatrix(currentCoords) && !_passedCoords.Contains(currentCoords))
                {
                    _passedCoords.Add(currentCoords);
                    var block = _blocksMatrix[currentCoords.x, currentCoords.y];
                    
                    if (block != null && block is ColorBlock colorBlock && colorBlock.BlockColor == color)
                    {
                        AddBlockToColorBlocksMap(colorBlock);
                        AddBlockToBlockCoordsMap(colorBlock, currentCoords);
                        FindBlocksByColor(color, currentCoords);
                    }
                }
            }
        }

        private void AddBlockToColorBlocksMap(ColorBlock block)
        {
            var colorId = block.BlockColor;
            if (!_colorBlocksMap.ContainsKey(colorId))
            {
                _colorBlocksMap.Add(colorId, new HashSet<ColorBlock>());
            }

            _colorBlocksMap[colorId].Add(block);
        }

        private void AddBlockToBlockCoordsMap(ColorBlock block, Vector2Int coords)
        {
            if (!_blockCoordsMap.ContainsKey(block))
            {
                _blockCoordsMap.Add(block, coords);
            }
        }

        private void FillDestroyMap()
        {
            if (_colorBlocksMap.Keys.Count == 0) return;

            var targetColor = GetColorOfMaxBlockCount();

            foreach (var block in _colorBlocksMap[targetColor])
            {
                var blockCoords = _blockCoordsMap[block];
                var x = Mathf.Abs(_startCoords.x - blockCoords.x);
                var y = Mathf.Abs(_startCoords.y - blockCoords.y);
                var level = x + y;
                if (level != 0)
                {
                    AddBlockToDestroyMap(level, block);
                }
            }
        }

        private BlockSpriteId GetColorOfMaxBlockCount()
        {
            var targetColor = BlockSpriteId.Red;
            var maxCount = 0;
            foreach (var color in _colorBlocksMap)
            {
                var blockCount = color.Value.Count;
                if (maxCount < blockCount)
                {
                    targetColor = color.Key;
                    maxCount = blockCount;
                }
            }

            return targetColor;
        }
    }
}