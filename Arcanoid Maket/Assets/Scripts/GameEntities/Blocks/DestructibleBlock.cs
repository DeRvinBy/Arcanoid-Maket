using System.Collections;
using EventInterfaces.BlockEvents;
using GameEntities.Blocks.Abstract;
using GameEntities.Blocks.Behaviour;
using GameEntities.Blocks.Enumerations;
using GameSettings.GameBlockSettings;
using MyLibrary.EventSystem;
using UnityEngine;

namespace GameEntities.Blocks
{
    public class DestructibleBlock : AbstractBlock
    {
        [SerializeField]
        private BlockSprite _sprite;
        
        [SerializeField]
        private BlockCollider _collider;

        [SerializeField]
        private BlockCracks _cracks;

        [SerializeField]
        private BlockParticles _particles;

        private BlockSettings _settings;
        private int _lifeCount;

        public override void Initialize(BlockSettings settings)
        {
            _settings = settings;
            _sprite.Initialize();
            _cracks.Initialize(_settings.LifeSettings);
        }

        public void SetupBlock(BlockId id)
        {
            _lifeCount = _settings.LifeSettings.BlockLife;
            _collider.SetupCollider();
            _cracks.SetupBlockCracks();
            var settings = _settings.GetBlockSettings(id);
            _sprite.SetupSprite(settings.Sprite);
            _particles.SetParticleColor(settings.ParticleColor);
            
            EventBus.RaiseEvent<IBlockOnSceneHandler>(a => a.OnDestructibleBlockCreated());
        }

        public override void Setup()
        {
            base.Setup();
            _collider.OnBlockCollided += OnBlockDamaged;
        }
        
        public override void Reset()
        {
            base.Reset();
            _collider.OnBlockCollided -= OnBlockDamaged;
        }

        private void OnBlockDamaged(Collision2D other)
        {
            _lifeCount -= 1;
            _cracks.UpdateBlockCracks(_lifeCount);
            if (_lifeCount <= 0)
            {
                StartCoroutine(DestroyBlock());
                EventBus.RaiseEvent<IBlockOnSceneHandler>(a => a.OnBlockStartDestroyed());    
            }
        }

        private IEnumerator DestroyBlock()
        {
            _sprite.ResetSprite();
            _collider.ResetCollider();
            _cracks.ResetBlockCracks();
            yield return _particles.PlayParticle();
            EventBus.RaiseEvent<IBlockOnSceneHandler>(a => a.OnDestroyBlock(this));
        }
    }
}