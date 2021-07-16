using Project.Scripts.GameEntities.Blocks;
using Project.Scripts.GameEntities.Blocks.Enumerations;
using Project.Scripts.GameEntities.GameField.Data.Grid;
using Project.Scripts.Utils.ObjectPool;
using UnityEngine;

namespace Project.Scripts.GameEntities.GameField
{
    public class FieldCreator : MonoBehaviour
    {
        private FieldGrid _gridDebug;
        
        public void CreateBlocksInGameField(FieldGrid grid)
        {
            _gridDebug = grid;
            var cellSize = grid.CellSize;
            var cells = grid.Cells;
            for (int i = 0; i < grid.VerticalCount; i++)
            {
                for (int j = 0; j < grid.HorizontalCount; j++)
                {
                    var cell = cells[i, j];
                    if (cell.BlockId != BlockId.Empty)
                    {
                        CreateBlock(cell, cellSize);
                    }
                }    
            }
        }

        private void CreateBlock(FieldCell cell, Vector2 cellSize)
        {
            var block = PoolsManager.Instance.GetObject<BlockEntity>(cell.Position);
            block.transform.localScale = cellSize;
            block.SetupBlock(cell.BlockId);
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