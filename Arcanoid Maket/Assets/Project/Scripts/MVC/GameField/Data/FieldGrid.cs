using Project.Scripts.GameSettings.GameFieldSettings;
using UnityEngine;

namespace Project.Scripts.MVC.GameField.Data
{
    public class FieldGrid
    {
        public int HorizontalCount { get; private set; }
        public int VerticalCount { get; private set; }
        public Vector2 CellSize { get; private set; }
        public FieldCell[,] Cells { get; private set; }
        
        private readonly FieldSettings _settings;
        private Vector2 _startPosition;

        public FieldGrid(FieldSettings fieldSettings)
        {
            _settings = fieldSettings;
            SetupStartPosition();
        }
        
        private void SetupStartPosition()
        {
            var camera = Camera.main;
            var screenSideOffset = Screen.width * _settings.SideOffset;
            var screenTopOffset = Screen.height - (Screen.height * _settings.TopOffset);
            var screenPosition = new Vector2(screenSideOffset, screenTopOffset);
            _startPosition = camera.ScreenToWorldPoint(screenPosition);
        }
        
        public void CreateGameField(int horizontalCount, int verticalCount)
        {
            HorizontalCount = horizontalCount;
            VerticalCount = verticalCount;
            
            SetupCellSize();
            CreateGrid();
        }

        private void SetupCellSize()
        {
            var camera = Camera.main;
            var worldHeight = camera.orthographicSize * 2f;
            var worldWidth = worldHeight * camera.aspect;
            worldWidth -= worldWidth * _settings.SideOffset * 2f;
            var sizeX = (worldWidth - _settings.CellMargin * (HorizontalCount - 1)) / HorizontalCount;
            var sizeY = sizeX / _settings.BlockAspect;
            CellSize = new Vector2(sizeX, sizeY);
        }

        private void CreateGrid()
        {
            Cells = new FieldCell[VerticalCount, HorizontalCount];
            
            var startLineX = _startPosition.x + CellSize.x / 2f;
            var startLineY =_startPosition.y - CellSize.y / 2f;
            var offsetX = CellSize.x + _settings.CellMargin;
            var offsetY = -CellSize.y - _settings.CellMargin;
            var position = new Vector2(startLineX, startLineY);
            
            for (int i = 0; i < VerticalCount; i++)
            {
                for (int j = 0; j < HorizontalCount; j++)
                {
                    Cells[i, j] = new FieldCell(position, 0);
                    position.x += offsetX;
                }

                position.x = startLineX;
                position.y += offsetY;
            }
        }
    }
}