using System.Collections.Generic;
using Project.Scripts.Architecture.Abstract;
using Project.Scripts.EntitiesCreation.BlockCreation;
using Project.Scripts.EventInterfaces.BlockEvents;
using Project.Scripts.EventInterfaces.GameEvents;
using Project.Scripts.EventInterfaces.StatesEvents;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.GameEntities.Blocks.SceneBlocks
{
    public class SceneBlocksManager : SceneEntitiesController, IMainGameStateEndHandler, IBlockOnSceneHandler
    {
        [SerializeField]
        private SceneBlocksUI _sceneBlocksUI;

        private List<BlockController> _blocksOnScene;

        public override void Initialize()
        {
            _blocksOnScene = new List<BlockController>();

            EventBus.Subscribe(this);
        }

        public void OnBlockCreated(BlockController block)
        {
            _blocksOnScene.Add(block);
            _sceneBlocksUI.SetupSlider(_blocksOnScene.Count);
        }

        public void OnBlockDestroyed(BlockController block)
        {
            _blocksOnScene.Remove(block);
            _sceneBlocksUI.UpdateSlider(_blocksOnScene.Count);
            if (_blocksOnScene.Count <= 0)
            {
                EventBus.RaiseEvent<IWinGameHandler>(a => a.OnWinGame());
            }
        }

        public void OnEndGame()
        {
            foreach (var block in _blocksOnScene)
            {
                BlockPoolManager.Instance.ReturnObject(block);
            }
            _blocksOnScene.Clear();
        }
    }
}