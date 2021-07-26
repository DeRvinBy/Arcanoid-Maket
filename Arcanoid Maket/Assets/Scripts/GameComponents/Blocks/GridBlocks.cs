using System.Collections.Generic;
using EventInterfaces.FieldEvents;
using GameComponents.Field;
using GameEntities.Blocks.Abstract;
using MyLibrary.EventSystem;
using UnityEngine;

namespace GameComponents.Blocks
{
    public class GridBlocks : MonoBehaviour, IFieldGridHandler
    {
        private Dictionary<Vector2, Vector2Int> _coordsMap;
        private AbstractBlock[,] _blocksMatrix;

        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(this);
        }

        public void AddBlockToMatrix(Vector2 position, AbstractBlock block)
        {
            var coords = _coordsMap[position];
            _blocksMatrix[coords.x, coords.y] = block;
        }

        public void RemoveBlockFromMatrix(AbstractBlock block)
        {
            var coords = _coordsMap[block.transform.position];
            _blocksMatrix[coords.x, coords.y] = null;
        }

        public Vector2Int GetBlocksCoordinates(Vector2 position)
        {
            return _coordsMap[position];
        }
        
        public AbstractBlock[,] GetBlocksMatrix()
        {
            return _blocksMatrix;
        }
        
        public void OnFieldGridCreated(FieldGrid grid)
        {
            _coordsMap = new Dictionary<Vector2, Vector2Int>();
            _blocksMatrix = new AbstractBlock[grid.HorizontalCount, grid.VerticalCount];
            var cells = grid.Cells;
            for (int i = 0; i < grid.VerticalCount; i++)
            {
                for (int j = 0; j < grid.HorizontalCount; j++)
                {
                    var position = cells[i, j].Position;
                    _coordsMap.Add(position, new Vector2Int(j, i));
                }
            }
        }
    }
}