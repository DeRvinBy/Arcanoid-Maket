﻿using Project.Scripts.GameEntities.Blocks;
using Project.Scripts.Utils.ObjectPool;
using UnityEngine;

namespace Project.Scripts.GameComponents.Blocks
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