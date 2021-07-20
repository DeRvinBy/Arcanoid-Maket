using System;
using System.Collections.Generic;
using GameEntities.Blocks;
using GameEntities.Blocks.Abstract;
using GameEntities.Blocks.Enumerations;
using Library.ObjectPool;
using UnityEngine;

namespace GameComponents.Blocks
{
    public class BlockSpawner
    {
        private Dictionary<Type, List<AbstractBlock>> _blocksMap;

        public BlockSpawner()
        {
            _blocksMap = new Dictionary<Type, List<AbstractBlock>>();
        }
        
        public void SpawnBlock(BlockId id, Vector3 position, Vector3 size, Transform parent)
        {
            if (id == BlockId.Indestructible)
            {
                CreateIndestructibleBlock(position, size, parent);
            }
            else
            {
                CreateDestructibleBlock(id, position, size, parent);
            }
        }

        private void CreateIndestructibleBlock(Vector3 position, Vector3 size, Transform parent)
        {
            var block = PoolsManager.Instance.GetObject<IndestructibleBlock>(position, Quaternion.identity, size, parent);
            AddPackToMap(typeof(IndestructibleBlock), block);
        }
        
        private void CreateDestructibleBlock(BlockId id, Vector3 position, Vector3 size, Transform parent)
        {
            var block = PoolsManager.Instance.GetObject<DestructibleBlock>(position, Quaternion.identity, size, parent);
            AddPackToMap(typeof(DestructibleBlock), block);
            block.SetupBlock(id);
        }

        private void AddPackToMap(Type type, AbstractBlock block)
        {
            if (!_blocksMap.ContainsKey(type))
            {
                _blocksMap.Add(type, new List<AbstractBlock>());
            }
            
            _blocksMap[type].Add(block);
        }

        public void DestroyBlock<T>(T block) where T : AbstractBlock
        {
            PoolsManager.Instance.ReturnObject(block);
            _blocksMap[typeof(T)].Remove(block);
        }

        public void DestroyAllBlocks()
        {
            foreach (var type in _blocksMap.Keys)
            {
                foreach (var block in _blocksMap[type])
                {
                    PoolsManager.Instance.ReturnObject(type, block);
                }
            }
            _blocksMap.Clear();
        }
    }
}