using System.Collections.Generic;
using Project.Scripts.BehaviorControllers.Abstract;
using Project.Scripts.EntitiesCreation.BlockCreation;
using Project.Scripts.EventInterfaces.BlockEvents;
using Project.Scripts.EventInterfaces.GameEvents;
using Project.Scripts.EventInterfaces.StatesEvents;
using Project.Scripts.Utils.EventSystem;
using Project.Scripts.Utils.ObjectPool;
using UnityEngine;

namespace Project.Scripts.GameEntities.Blocks.SceneBlocks
{
    public class BlocksManager : EntityController, IEndGameplayHandler, IBlockOnSceneHandler, IPrepareGameplayHandler
    {
        [SerializeField]
        private BlocksProgressUI _blocksProgressUI;

        private List<BlockEntity> _blocksOnScene;

        public override void Initialize()
        {
            _blocksOnScene = new List<BlockEntity>();

            EventBus.Subscribe(this);
        }

        public void OnBlockCreated(BlockEntity block)
        {
            _blocksOnScene.Add(block);
            _blocksProgressUI.SetupSlider(_blocksOnScene.Count);
        }

        public void OnBlockDestroyed(BlockEntity block)
        {
            _blocksOnScene.Remove(block);
            _blocksProgressUI.UpdateSlider(_blocksOnScene.Count);
            if (_blocksOnScene.Count <= 0)
            {
                EventBus.RaiseEvent<IEndGameHandler>(a => a.OnWinGame());
            }
        }
        
        public void OnPrepareGame()
        {
            _blocksProgressUI.SetupSlider(_blocksOnScene.Count);
        }

        public void OnEndGame()
        {
            foreach (var block in _blocksOnScene)
            {
                PoolsManager.Instance.ReturnObject(block);
            }
            _blocksOnScene.Clear();
        }
    }
}