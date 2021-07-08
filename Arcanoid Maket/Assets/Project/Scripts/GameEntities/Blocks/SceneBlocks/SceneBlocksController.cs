using Project.Scripts.Architecture.Abstract;
using Project.Scripts.EventInterfaces.BlockEvents;
using Project.Scripts.EventInterfaces.GameEvents;
using Project.Scripts.EventInterfaces.GameFieldEvents;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.GameEntities.Blocks.SceneBlocks
{
    public class SceneBlocksController : SceneEntitiesController, IGameFieldCreatedHandler, IBlockDestroyedHandler
    {
        [SerializeField]
        private SceneBlocksUI _sceneBlocksUI;

        private SceneBlocksModel _model;

        public override void Initialize()
        {
            _model = new SceneBlocksModel();
            _model.OnBlockCountReduced += _sceneBlocksUI.UpdateSlider;
            _model.OnBlockCountReduced += CompleteLevel;

            EventBus.Subscribe(this);
        }

        public void OnBlocksCreated(int blockCount)
        {
            _model.SetBlockCount(blockCount);
            _sceneBlocksUI.SetupSlider(blockCount);
        }

        public void OnBlockDestroyed()
        {
            _model.ReduceBLockCount();
        }

        private void CompleteLevel(int blockCount)
        {
            if (blockCount <= 0)
            {
                EventBus.RaiseEvent<IWinGameHandler>(a => a.OnWinGame());
            }
        }
    }
}