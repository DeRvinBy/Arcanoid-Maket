using System;
using Project.Scripts.GameSettings.GameBlockSettings.Enumerations;
using Project.Scripts.MVC.Blocks.Creation;
using Project.Scripts.MVC.GameField.Data.Grid;
using UnityEngine;

namespace Project.Scripts.MVC.GameField
{
    public class FieldView : MonoBehaviour
    {
        private FieldGrid _gridDebug;
        
        public void CreateBlocksInField(FieldGrid grid)
        {
            _gridDebug = grid;
            var cells = grid.Cells;
            for (int i = 0; i < grid.VerticalCount; i++)
            {
                for (int j = 0; j < grid.HorizontalCount; j++)
                {
                    var cell = cells[i, j];
                    if (cell.Data != BlockId.Empty)
                    {
                        CreateBlock(cell, grid.CellSize);
                    }
                }    
            }
        }

        private void CreateBlock(FieldCell cell, Vector2 cellSize)
        {
            var block = BlockPoolManager.GetObject(cell.Position);
            block.transform.localScale = cellSize;
            block.Initialize(cell.Data);
        }

        private void OnDrawGizmos()
        {
            if (_gridDebug != null)
            {
                var cells = _gridDebug.Cells;
                for (int i = 0; i < _gridDebug.VerticalCount; i++)
                {
                    for (int j = 0; j < _gridDebug.HorizontalCount; j++)
                    {
                        var cell = cells[i, j];
                        Gizmos.DrawWireCube(cell.Position, _gridDebug.CellSize);
                    }    
                }
            }
        }
    }
}