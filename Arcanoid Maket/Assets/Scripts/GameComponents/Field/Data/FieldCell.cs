using GameEntities.Blocks.Data;
using UnityEngine;

namespace GameComponents.Field.Data
{
    public class FieldCell
    {
        public Vector2 Position { get; private set; }
        public BlockProperties Properties { get; private set; }
        
        public FieldCell(Vector2 position, BlockProperties properties)
        {
            Position = position;
            Properties = properties;
        }
    }
}