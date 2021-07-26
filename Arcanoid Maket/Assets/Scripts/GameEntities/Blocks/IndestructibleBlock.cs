﻿using System.Collections;
using EventInterfaces.BlockEvents;
using GameEntities.Blocks.Abstract;
using GameEntities.Blocks.Components;
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

        private BlockSettings _settings;
        private bool _isDestroying;
        
        public override void Initialize(BlockSettings settings)
        {
            _sprite.Initialize();
            _settings = settings;
        }

        public void SetupBlock()
        {
            var settings = _settings.GetBlockSettings(BlockSpriteId.Iron);
            _sprite.SetupSprite(settings.Sprite);
            _particles.SetParticleColor(settings.ParticleColor);
        }

        public override void OnSetup()
        {
            base.OnSetup();
            _isDestroying = false;
        }

        public override void DestroyBlock()
        {
            if (_isDestroying) return;
            
            _isDestroying = true;
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