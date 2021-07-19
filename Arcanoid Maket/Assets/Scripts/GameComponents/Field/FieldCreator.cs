using EventInterfaces.BlockEvents;
using GameComponents.Field.Data;
using GameEntities.Blocks.Enumerations;
using Library.EventSystem;
using UnityEngine;

namespace GameComponents.Field
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
            EventBus.RaiseEvent<IBlockOnSceneHandler>(a => 
                a.OnCreateBlock(cell.Position, cellSize, transform, cell.BlockId));
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