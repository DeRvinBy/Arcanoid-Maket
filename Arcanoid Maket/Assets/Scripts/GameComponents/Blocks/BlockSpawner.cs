using GameEntities.Blocks;
using GameEntities.Blocks.Abstract;
using GameEntities.Blocks.Enumerations;
using Library.ObjectPool;
using UnityEngine;

namespace GameComponents.Blocks
{
    public class BlockSpawner
    {
        public AbstractBlock SpawnBlock(BlockId id, Vector3 position, Vector3 size, Transform parent)
        {
            return CreateDestructibleBlock(id, position, size, parent);
        }

        private AbstractBlock CreateDestructibleBlock(BlockId id, Vector3 position, Vector3 size, Transform parent)
        {
            var block = PoolsManager.Instance.GetObject<DestructibleBlock>(position, Quaternion.identity, size, parent);
            block.SetupBlock(id);
            return block;
        }

        public void DestroyBlock<T>(T block) where T : AbstractBlock
        {
            PoolsManager.Instance.ReturnObject(block);
        }
    }
}