using Project.Scripts.GameSettings.GameBlockSettings.Enumerations;
using UnityEngine;

namespace Project.Scripts.MVC.GameField.Data.Grid
{
    public class FieldCell
    {
        public Vector2 Position { get; private set; }
        public BlockId Data { get; private set; }
        
        public FieldCell(Vector2 position, int data)
        {
            Position = position;
            Data = (BlockId)data;
        }
    }
}