using UnityEngine;

namespace Project.Scripts.MVC.GameField
{
    public class FieldView : MonoBehaviour
    {
        private FieldModel _model;

        private Vector2 _position;

        public void Initialize(FieldModel model)
        {
            _model = model;
        }

        public void StartView()
        {
            
        }

        private void OnDrawGizmos()
        {
            if (_model != null)
            {
                var grid = _model.Grid;
                var cells = grid.Cells;
                for (int i = 0; i < grid.VerticalCount; i++)
                {
                    for (int j = 0; j < grid.HorizontalCount; j++)
                    {
                        var cell = cells[i,j];
                        Gizmos.DrawWireCube(cell.Position, grid.CellSize);
                    }    
                }
            }
        }
    }
}