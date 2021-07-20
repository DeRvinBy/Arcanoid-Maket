using GameComponents.Field.Data;
using GameEntities.Blocks.Data;
using GameEntities.Blocks.Enumerations;
using GamePacks.Data.Level;
using GamePacks.Data.Level.LevelParser.Tiles;
using UnityEngine;

namespace GameComponents.Field
{
    public class FieldGrid
    {
        public int HorizontalCount { get; private set; }
        public int VerticalCount { get; private set; }
        public Vector2 CellSize { get; private set; }
        public FieldCell[,] Cells { get; private set; }

        private FieldProperties _properties;
        private Vector2 _startPosition;
        private float _cellMargin;

        public void Initialize(FieldProperties properties)
        {
            _properties = properties;
            _startPosition = _properties.GetStartPosition();
            _cellMargin = _properties.GetCellMargin();
        }
        
        public void CreateGameField(LevelData levelData)
        {
            VerticalCount = levelData.VerticalCount;
            HorizontalCount = levelData.HorizontalCount;
            CellSize = _properties.GetCellSize(HorizontalCount);
            SetupCells(levelData.Data);
        }
        
        private void SetupCells(TileProperties[,] data)
        {
            Cells = new FieldCell[VerticalCount, HorizontalCount];

            var startLineX = _startPosition.x + CellSize.x / 2f;
            var startLineY =_startPosition.y - CellSize.y / 2f;
            var stepX = CellSize.x + _cellMargin;
            var stepY = -CellSize.y - _cellMargin;
            var position = new Vector2(startLineX, startLineY);
            
            for (int i = 0; i < VerticalCount; i++)
            {
                for (int j = 0; j < HorizontalCount; j++)
                {
                    var properties = CreateBlockProperties(data[i, j]);
                    Cells[i, j] = new FieldCell(position, properties);
                    position.x += stepX;
                }
                position.x = startLineX;
                position.y += stepY;
            }
        }

        private BlockProperties CreateBlockProperties(TileProperties properties)
        {
            return new BlockProperties
            {
                Type = (BlockType) properties.TypeId,
                SpriteId = (BlockSpriteId) properties.SpriteId,
                BonusId = properties.BonusId
            };
        }
    }
}