using System;
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
            Vector2Int.left, Vector2Int.up, Vector2Int.right, Vector2Int.down
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
            FindColorsBlock();
            FillDestroyMap();
            return _destroyBlocksMap;
        }

        private void FindColorsBlock()
        {
            var nextMovesMap = new Dictionary<Vector2Int, BlockSpriteId>();
            foreach (var direction in _moveDirections)
            {
                var currentCoords = _startCoords + direction;
                if (IsWithinInMatrix(currentCoords))
                {
                    _passedCoords.Add(currentCoords);
                    var colorBlock = GetColorBlock(currentCoords);
                    if (colorBlock != null)
                    {
                        AddBlockToMaps(colorBlock, currentCoords);
                        nextMovesMap.Add(currentCoords, colorBlock.BlockColor);
                    }
                }
            }

            foreach (var pair in nextMovesMap)
            {
                FindBlocksByColor(pair.Key, pair.Value);
            }
        }

        private void FindBlocksByColor(Vector2Int coords, BlockSpriteId color)
        {
            foreach (var direction in _moveDirections)
            {
                var currentCoords = coords + direction;
                if (IsWithinInMatrix(currentCoords) && !_passedCoords.Contains(currentCoords))
                {
                    _passedCoords.Add(currentCoords);

                    var colorBlock = GetColorBlock(currentCoords);
                    if (colorBlock != null && colorBlock.BlockColor == color)
                    {
                        AddBlockToMaps(colorBlock, currentCoords);
                        FindBlocksByColor(currentCoords, color);
                    }
                }
            }
        }
        private ColorBlock GetColorBlock(Vector2Int coords)
        {
            var block = _blocksMatrix[coords.x, coords.y] as ColorBlock;
            return block;
        }
        
        private void AddBlockToMaps(ColorBlock block, Vector2Int coords)
        {
            var colorId = block.BlockColor;
            if (!_colorBlocksMap.ContainsKey(colorId))
            {
                _colorBlocksMap.Add(colorId, new HashSet<ColorBlock>());
            }

            _colorBlocksMap[colorId].Add(block);
            
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
            foreach (var pair in _colorBlocksMap)
            {
                var blockCount = pair.Value.Count;
                if (maxCount < blockCount)
                {
                    targetColor = pair.Key;
                    maxCount = blockCount;
                }
            }

            return targetColor;
        }
    }
}