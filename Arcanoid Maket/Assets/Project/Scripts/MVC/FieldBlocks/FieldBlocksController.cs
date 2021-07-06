﻿using Project.Scripts.MVC.Abstract;
using Project.Scripts.MVC.Blocks.EventInterfaces;
using Project.Scripts.MVC.GameField.EventInterfaces;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.MVC.FieldBlocks
{
    public class FieldBlocksController : SceneEntitiesController, IGameFieldCreatedEvent, IBlockDestroyedEvent
    {
        [SerializeField]
        private FieldBlocksUI _blocksUI;
        
        private FieldBlocksModel _model;
        
        public override void Initialize()
        {
            _model = new FieldBlocksModel();
            _model.OnBlockCountReduced += _blocksUI.UpdateSlider;
            
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
    }
}