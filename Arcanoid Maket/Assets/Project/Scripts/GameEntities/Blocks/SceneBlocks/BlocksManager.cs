using System.Collections.Generic;
using Project.Scripts.BehaviorControllers.Abstract;
using Project.Scripts.EventInterfaces.BlockEvents;
using Project.Scripts.EventInterfaces.GameEvents;
using Project.Scripts.EventInterfaces.StatesEvents;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.GameEntities.Blocks.SceneBlocks
{
    public class BlocksManager : EntityController, IBlockOnSceneHandler, IPrepareGameplayHandler
    {
        [SerializeField]
        private BlocksProgressUI _blocksProgressUI;

        private int _blockCount;
        private List<BlockEntity> _blocksOnScene;

        public override void Initialize()
        {
            _blocksOnScene = new List<BlockEntity>();
            _blocksProgressUI.Initialize();

            EventBus.Subscribe(this);
        }

        public void OnBlockCreated(BlockEntity block)
        {
            _blocksOnScene.Add(block);
            _blockCount++;
            _blocksProgressUI.SetupSlider(_blockCount);  
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

        public void OnBlockEndDestroyed(BlockEntity block)
        {
            _blocksOnScene.Remove(block);
        }

        public void OnPrepareGame()
        {
            _blockCount = 0;
            DestroyAllBalls();
        }
        
        private void DestroyAllBalls()
        {
            foreach (var block in _blocksOnScene)
            {
                block.DestroyBlockImmediate();
            }
            _blocksOnScene.Clear();
        }
    }
}