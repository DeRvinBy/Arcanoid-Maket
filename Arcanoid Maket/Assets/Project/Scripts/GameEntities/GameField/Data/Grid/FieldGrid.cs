﻿using Project.Scripts.GameEntities.GameField.Components;
using Project.Scripts.Packs.Data.Level;
using UnityEngine;

namespace Project.Scripts.GameEntities.GameField.Data.Grid
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
        
        public FieldGrid(FieldProperties properties)
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
            CreateGrid(levelData.Data);
        }
        
        private void CreateGrid(int[,] data)
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
                    Cells[i, j] = new FieldCell(position, data[i, j]);
                    position.x += stepX;
                }

                position.x = startLineX;
                position.y += stepY;
            }
        }
    }
}