﻿using System.Collections;
using EventInterfaces.BlockEvents;
using GameEntities.Blocks.Abstract;
using GameEntities.Blocks.Behaviour;
using GameEntities.Blocks.Enumerations;
using GameSettings.GameBlockSettings;
using MyLibrary.EventSystem;
using UnityEngine;

namespace GameEntities.Blocks
{
    public class IndestructibleBlock : AbstractBlock
    {
        [SerializeField]
        private BlockSprite _sprite;
        
        [SerializeField]
        private BlockParticles _particles;
        
        public override void Initialize(BlockSettings settings)
        {
            _sprite.Initialize();
            var visualSettings = settings.GetBlockSettings(BlockSpriteId.Iron); 
            _sprite.SetupSprite(visualSettings.Sprite);
        }

        public override void DestroyBlock()
        {
            StartCoroutine(DestroyBlockAnimate());
        }
        
        private IEnumerator DestroyBlockAnimate()
        {
            _sprite.ResetSprite();
            yield return _particles.PlayParticle();
            EventBus.RaiseEvent<IBlockOnSceneHandler>(a => a.OnDestroyBlock(this));
        }
    }
}