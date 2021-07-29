using System;
using System.Collections.Generic;
using System.Linq;
using EventInterfaces.BonusEvents;
using GameEntities.Blocks;
using GameEntities.Blocks.Abstract;
using GameEntities.Blocks.Data;
using GameEntities.Blocks.Enumerations;
using MyLibrary.EventSystem;
using MyLibrary.ObjectPool;
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
        
        public AbstractBlock SpawnBlock(BlockProperties properties, Vector3 position, Vector3 size, Transform parent)
        {
            switch (properties.Type)
            {
                case BlockType.ColorBlock:
                    return CreateColorBlock(properties.SpriteId, position, size, parent);
                case BlockType.Indestructible:
                    return CreateIndestructibleBlock(position, size, parent);
                case BlockType.WithSpawningBonus:
                    var spawningBonusBlock = CreateBonusBLock(properties, position, size, parent);
                    spawningBonusBlock.OnBlockDestroy += () =>
                        EventBus.RaiseEvent<IBonusOnSceneHandler>(a =>
                            a.OnCreateBonusObject(properties.BonusId, position));
                    return spawningBonusBlock;
                case BlockType.WithInstantBonus:
                    var instantBonusBlock = CreateBonusBLock(properties, position, size, parent);
                    instantBonusBlock.OnBlockDestroy += () =>
                        EventBus.RaiseEvent<IBonusOnSceneHandler>(a =>
                            a.OnStartBonusAtPosition(properties.BonusId, position));
                    return instantBonusBlock;
            }

            return null;
        }

        private AbstractBlock CreateIndestructibleBlock(Vector3 position, Vector3 size, Transform parent)
        {
            var block = PoolsManager.Instance.GetObject<IndestructibleBlock>(position, Quaternion.identity, size, parent);
            AddBlockToMap(typeof(IndestructibleBlock), block);
            block.SetupBlock();
            return block;
        }
        
        private AbstractBlock CreateColorBlock(BlockSpriteId spriteId, Vector3 position, Vector3 size, Transform parent)
        {
            var block = PoolsManager.Instance.GetObject<ColorBlock>(position, Quaternion.identity, size, parent);
            AddBlockToMap(typeof(ColorBlock), block);
            block.SetupBlock(spriteId);
            return block;
        }
        
        private BonusBlock CreateBonusBLock(BlockProperties properties, Vector3 position, Vector3 size, Transform parent)
        {
            var block = PoolsManager.Instance.GetObject<BonusBlock>(position, Quaternion.identity, size, parent);
            AddBlockToMap(typeof(BonusBlock), block);
            block.SetupBlock(properties.SpriteId);
            block.SetupBonusBLock(properties.BonusId);
            return block;
        }

        private void AddBlockToMap(Type type, AbstractBlock block)
        {
            if (!_blocksMap.ContainsKey(type))
            {
                _blocksMap.Add(type, new List<AbstractBlock>());
            }
            
            _blocksMap[type].Add(block);
        }

        public List<T> GetBlocks<T>() where T : AbstractBlock
        {
            var type = typeof(T);
            if (_blocksMap.ContainsKey(type))
            {
                return _blocksMap[type].Select(b => b as T).ToList();
            }
            
            return null;
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