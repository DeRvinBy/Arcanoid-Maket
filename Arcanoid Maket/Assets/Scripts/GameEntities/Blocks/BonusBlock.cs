using System;
using EventInterfaces.BlockEvents;
using GameEntities.Blocks.Components;
using GameEntities.Bonuses.Enumerations;
using GameSettings.GameBlockSettings;
using GameSettings.GameBonusSettings.ObjectSettings;
using MyLibrary.EventSystem;
using UnityEngine;

namespace GameEntities.Blocks
{
    public class BonusBlock : DestructibleBlock
    {
        public event Action OnBlockDestroy;

        [SerializeField]
        private BlockSprite _blockBonusSprite;
        
        private BonusObjectSettings _bonusSettings;
        
        public override void Initialize(BlockSettings settings)
        {
            base.Initialize(settings);
            _bonusSettings = settings.BonusObjectSettings;
        }

        public void SetupBonusBLock(BonusType type)
        {
            var sprite = _bonusSettings.GetBonusSprite(type);
            _blockBonusSprite.SetupSprite(sprite);
        }

        public override void OnReset()
        {
            base.OnReset();
            OnBlockDestroy = null;
        }

        public override void DestroyBlock()
        {
            base.DestroyBlock();
            _blockBonusSprite.ResetSprite();
            OnBlockDestroy?.Invoke();
        }
        
        protected override void DestroyCompleteBlock()
        {
            EventBus.RaiseEvent<IBlockOnSceneHandler>(a => a.OnDestroyBlock(this));   
        }
    }
}