using System.Collections.Generic;
using Scripts.BehaviorControllers.Abstract;
using Scripts.EventInterfaces.BlockEvents;
using Scripts.EventInterfaces.GameEvents;
using Scripts.EventInterfaces.StatesEvents;
using Scripts.GameComponents.Blocks;
using Scripts.GameEntities.Blocks;
using Scripts.GameEntities.Blocks.Enumerations;
using Scripts.UI.Header.BlocksUI;
using Scripts.Utils.EventSystem;
using UnityEngine;

namespace Scripts.BehaviorControllers.EntitiesControllers.EntitiesManagers
{
    public class BlocksManager : EntityController, IBlockOnSceneHandler, IPrepareGameplayHandler, IStartGameplayHandler
    {
        [SerializeField]
        private BlocksProgressUI _blocksProgressUI;

        private BlockSpawner _spawner;
        private List<BlockEntity> _blocksOnScene;
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
            _blocksOnScene = new List<BlockEntity>();
        }

        public void OnCreateBlock(Vector3 position, Vector3 size, Transform parent, BlockId blockId)
        {
            var block = _spawner.SpawnBlock(position, size, parent);
            block.SetupBlock(blockId);
            _blocksOnScene.Add(block);
            _blockCount++;
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

        public void OnDestroyBlock(BlockEntity block)
        {
            _spawner.DestroyBlock(block);
            _blocksOnScene.Remove(block);
        }
        
        public void OnStartGame()
        {
            _blocksProgressUI.SetupSlider(_blockCount);  
        }
        
        public void OnPrepareGame()
        {
            DestroyAllBalls();
            _blocksProgressUI.ResetSlider();
        }
        
        private void DestroyAllBalls()
        {
            foreach (var block in _blocksOnScene)
            {
                _spawner.DestroyBlock(block);
            }
            _blocksOnScene.Clear();
            _blockCount = 0;
        }
    }
}