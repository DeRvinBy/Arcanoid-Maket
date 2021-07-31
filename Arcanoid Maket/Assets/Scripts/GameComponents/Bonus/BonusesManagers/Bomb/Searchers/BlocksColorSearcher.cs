using System.Collections.Generic;
using System.Linq;
using GameComponents.Blocks;
using GameEntities.Blocks;
using GameEntities.Blocks.Abstract;
using GameEntities.Blocks.Enumerations;
using UnityEngine;

namespace GameComponents.Bonus.BonusesManagers.Bomb.Searchers
{
    public class BlocksColorSearcher : AbstractBlocksSearcher
    {
        private int _level;
        private readonly List<Vector2Int> _moveDirections = new List<Vector2Int>
        {
            Vector2Int.left, Vector2Int.up, Vector2Int.right, Vector2Int.down
        };
        private Dictionary<BlockSpriteId, HashSet<ColorBlock>> _colorBlocksMap;
        private Dictionary<ColorBlock, Vector2Int> _blockCoordsMap;

        public BlocksColorSearcher(Vector2 bonusPosition, GridBlocks gridBlocks) : base(bonusPosition, gridBlocks)
        {
            _level = 1;
            _colorBlocksMap = new Dictionary<BlockSpriteId, HashSet<ColorBlock>>();
            _blockCoordsMap = new Dictionary<ColorBlock, Vector2Int>();
            FindColorsBlock();
        }

        public override bool IsHasNextBlocks()
        {
            return true;
        }

        public override List<AbstractBlock> GetNextDestroyList()
        {
            _destroyList = new List<AbstractBlock>();
            FillDestroyMap();
            return _destroyList;
        }

        private void FindColorsBlock()
        {
            var nextMovesMap = new Dictionary<Vector2Int, BlockSpriteId>();
            foreach (var direction in _moveDirections)
            {
                var currentCoords = _startCoords + direction;
                if (IsWithinInMatrix(currentCoords))
                {
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
                if (IsWithinInMatrix(currentCoords))
                {
                    var colorBlock = GetColorBlock(currentCoords);
                    if (IsMatchingBlock(colorBlock, color))
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

        private bool IsMatchingBlock(ColorBlock block, BlockSpriteId color)
        {
            return block != null && !_blockCoordsMap.Keys.Contains(block) && block.BlockColor == color;
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
                if (level == _level)
                {
                    AddBlockToDestroyList(block);
                }
            }

            foreach (var block in _destroyList.Cast<ColorBlock>())
            {
                _colorBlocksMap[targetColor].Remove(block);
            }

            _level++;
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