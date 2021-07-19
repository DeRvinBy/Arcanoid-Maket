using GameEntities.Blocks;
using Library.ObjectPool;
using UnityEngine;

namespace GameComponents.Blocks
{
    public class BlockSpawner
    {
        public BlockEntity SpawnBlock(Vector3 position, Vector3 size, Transform parent)
        {
            return PoolsManager.Instance.GetObject<BlockEntity>(position, Quaternion.identity, size, parent);
        }

        public void DestroyBlock(BlockEntity block)
        {
            PoolsManager.Instance.ReturnObject(block);
        }
    }
}