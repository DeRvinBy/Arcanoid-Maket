using System.Collections.Generic;
using BehaviorControllers.Abstract;
using EventInterfaces.BlockEvents;
using EventInterfaces.GameEvents;
using EventInterfaces.StatesEvents;
using GameComponents.Blocks;
using GameEntities.Blocks.Abstract;
using GameEntities.Blocks.Enumerations;
using Library.EventSystem;
using UI.Header.BlocksUI;
using UnityEngine;

namespace BehaviorControllers.EntitiesControllers.EntitiesManagers
{
    public class BlocksManager : EntityController, IBlockOnSceneHandler, IPrepareGameplayHandler, IStartGameplayHandler
    {
        [SerializeField]
        private BlocksProgressUI _blocksProgressUI;

        private BlockSpawner _spawner;
        private int _blockCount;

        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(this);
        }

        public override void Initialize()
        {
            _spawner = new BlockSpawner();
        }

        public void OnDestructibleBlockCreated()
        {
            _blockCount++;
        }

        public void OnCreateBlock(Vector3 position, Vector3 size, Transform parent, BlockId blockId)
        {
            _spawner.SpawnBlock(blockId, position, size, parent);
        }

        public void OnBlockStartDestroyed()
        {
            _blockCount--;
            _blocksProgressUI.UpdateSlider(_blockCount);
            if (_blockCount <= 0)
            {
                EventBus.RaiseEvent<IEndGameHandler>(a => a.OnWinGame());
            }
        }

        public void OnDestroyBlock<T>(T block) where T : AbstractBlock
        {
            _spawner.DestroyBlock(block);
        }
        
        public void OnStartGame()
        {
            _blocksProgressUI.SetupSlider(_blockCount);  
        }
        
        public void OnPrepareGame()
        {
            _spawner.DestroyAllBlocks();
            _blockCount = 0;
            _blocksProgressUI.ResetSlider();
        }
    }
}