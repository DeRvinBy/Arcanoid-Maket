﻿using System;
using System.Collections.Generic;
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
        
        public void SpawnBlock(BlockProperties properties, Vector3 position, Vector3 size, Transform parent)
        {
            switch (properties.Type)
            {
                case BlockType.Destructible:
                    CreateDestructibleBlock(properties.SpriteId, position, size, parent);
                    break;
                case BlockType.Indestructible:
                    CreateIndestructibleBlock(position, size, parent);
                    break;
                case BlockType.WithSpawningBonus:
                    var spawningBonusBlock = CreateBonusBLock(properties, position, size, parent);
                    spawningBonusBlock.OnBlockDestroy += () =>
                        EventBus.RaiseEvent<IBonusOnSceneHandler>(a =>
                            a.OnCreateBonusObject(properties.BonusId, position));
                    break;
                case BlockType.WithInstantBonus:
                    var instantBonusBlock = CreateBonusBLock(properties, position, size, parent);
                    instantBonusBlock.OnBlockDestroy += () =>
                        EventBus.RaiseEvent<IBonusOnSceneHandler>(a =>
                            a.OnStartBonusAtPosition(properties.BonusId, position));
                    break;
            }
        }

        private void CreateIndestructibleBlock(Vector3 position, Vector3 size, Transform parent)
        {
            var block = PoolsManager.Instance.GetObject<IndestructibleBlock>(position, Quaternion.identity, size, parent);
            AddPackToMap(typeof(IndestructibleBlock), block);
        }
        
        private void CreateDestructibleBlock(BlockSpriteId spriteId, Vector3 position, Vector3 size, Transform parent)
        {
            var block = PoolsManager.Instance.GetObject<DestructibleBlock>(position, Quaternion.identity, size, parent);
            AddPackToMap(typeof(DestructibleBlock), block);
            block.SetupBlock(spriteId);
        }
        
        private BonusBlock CreateBonusBLock(BlockProperties properties, Vector3 position, Vector3 size, Transform parent)
        {
            var block = PoolsManager.Instance.GetObject<BonusBlock>(position, Quaternion.identity, size, parent);
            AddPackToMap(typeof(BonusBlock), block);
            block.SetupBlock(properties.SpriteId);
            return block;
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