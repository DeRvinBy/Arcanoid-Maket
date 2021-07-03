using Project.Scripts.GameSettings.GameFieldSettings;
using Project.Scripts.MVC.GameField.Data.Level;
using UnityEngine;

namespace Project.Scripts.MVC.GameField.Data.Grid
{
    public class FieldGrid
    {
        public int HorizontalCount { get; private set; }
        public int VerticalCount { get; private set; }
        public Vector2 CellSize { get; private set; }
        public FieldCell[,] Cells { get; private set; }
        
        private readonly FieldSettings _settings;
        private readonly Camera _camera;
        private Vector2 _startPosition;

        public FieldGrid(Camera camera, FieldSettings fieldSettings)
        {
            _camera = camera;
            _settings = fieldSettings;
            SetupStartPosition();
        }
        
        private void SetupStartPosition()
        {
            var screenSideOffset = Screen.width * _settings.SideOffset;
            var screenTopOffset = Screen.height - (Screen.height * _settings.TopOffset);
            var screenPosition = new Vector2(screenSideOffset, screenTopOffset);
            _startPosition = _camera.ScreenToWorldPoint(screenPosition);
        }
        
        public void CreateGameField(LevelData levelData)
        {
            VerticalCount = levelData.VerticalCount;
            HorizontalCount = levelData.HorizontalCount;

            SetupCellSize();
            CreateGrid(levelData.Data);
        }

        private void SetupCellSize()
        {
            var worldHeight = _camera.orthographicSize * 2f;
            var worldWidth = worldHeight * _camera.aspect;
            worldWidth -= worldWidth * _settings.SideOffset * 2f;
            var sizeX = (worldWidth - _settings.CellMargin * (HorizontalCount - 1)) / HorizontalCount;
            var sizeY = sizeX / _settings.BlockAspect;
            CellSize = new Vector2(sizeX, sizeY);
        }

        private void CreateGrid(int[,] data)
        {
            Cells = new FieldCell[VerticalCount, HorizontalCount];

            var startLineX = _startPosition.x + CellSize.x / 2f;
            var startLineY =_startPosition.y - CellSize.y / 2f;
            var stepX = CellSize.x + _settings.CellMargin;
            var stepY = -CellSize.y - _settings.CellMargin;
            var position = new Vector2(startLineX, startLineY);
            
            for (int i = 0; i < VerticalCount; i++)
            {
                for (int j = 0; j < HorizontalCount; j++)
                {
                    Cells[i, j] = new FieldCell(position, data[i, j]);
                    position.x += stepX;
                }

                position.x = startLineX;
                position.y += stepY;
            }
        }
    }
}