using UnityEngine;

namespace Project.Scripts.MVC.GameField.Data.Grid
{
    public class FieldCell
    {
        public Vector2 Position { get; private set; }
        public int Data { get; private set; }
        
        public FieldCell(Vector2 position, int data)
        {
            Position = position;
            Data = data;
        }
    }
}