using Project.Scripts.Architecture.Abstract;
using Project.Scripts.EventInterfaces.BlockEvents;
using Project.Scripts.EventInterfaces.GameEvents;
using Project.Scripts.EventInterfaces.GameFieldEvents;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.GameEntities.FieldBlocks
{
    public class FieldBlocksController : SceneEntitiesController, IGameFieldCreatedEvent, IBlockDestroyedHandler
    {
        [SerializeField]
        private FieldBlocksUI _blocksUI;

        private FieldBlocksModel _model;

        public override void Initialize()
        {
            _model = new FieldBlocksModel();
            _model.OnBlockCountReduced += _blocksUI.UpdateSlider;
            _model.OnBlockCountReduced += CompleteLevel;

            EventBus.Subscribe(this);
        }

        public void OnBlocksCreated(int blockCount)
        {
            _model.SetBlockCount(blockCount);
            _blocksUI.SetupSlider(blockCount);
        }

        public void OnBlockDestroyed()
        {
            _model.ReduceBLockCount();
        }

        private void CompleteLevel(int blockCount)
        {
            if (blockCount <= 0)
            {
                EventBus.RaiseEvent<IEndGameHandler>(a => a.OnWinGame());
            }
        }
    }
}