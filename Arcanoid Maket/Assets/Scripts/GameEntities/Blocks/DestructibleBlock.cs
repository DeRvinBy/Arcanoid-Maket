using System.Collections;
using EventInterfaces.BlockEvents;
using GameEntities.Ball;
using GameEntities.Blocks.Abstract;
using GameEntities.Blocks.Components;
using GameEntities.Blocks.Enumerations;
using GameSettings.GameBlockSettings;
using MyLibrary.CollisionStorage.Extensions;
using MyLibrary.EventSystem;
using UnityEngine;

namespace GameEntities.Blocks
{
    public abstract class DestructibleBlock : AbstractBlock
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
        private bool _isDestroying;
        private int _lifeCount;

        public override void Initialize(BlockSettings settings)
        {
            _settings = settings;
            _sprite.Initialize();
            _cracks.Initialize(_settings.LifeSettings);
        }

        public virtual void SetupBlock(BlockSpriteId spriteId)
        {
            _lifeCount = _settings.LifeSettings.BlockLife;
            _cracks.SetupBlockCracks();
            _collider.EnableCollider();
            var settings = _settings.GetBlockSettings(spriteId);
            _sprite.SetupSprite(settings.Sprite);
            _particles.SetParticleColor(settings.ParticleColor);
            
            EventBus.RaiseEvent<IBlockOnSceneHandler>(a => a.OnDestructibleBlockCreated());
        }

        public void EnableBlockTrigger()
        {
            _collider.EnableTrigger();
        }
        
        public void DisableBlockTrigger()
        {
            _collider.DisableTrigger();
        }

        public override void OnSetup()
        {
            base.OnSetup();
            _isDestroying = false;
            _collider.RegisterCollider(this);
            _collider.OnCollisionEnter += OnBlockDamaged;
            _collider.OnTriggerEnter += DestroyBlock;
        }
        
        public override void OnReset()
        {
            base.OnReset();
            _collider.DisableTrigger();
            _collider.UnregisterCollider(this);
            _collider.OnCollisionEnter -= OnBlockDamaged;
            _collider.OnTriggerEnter -= DestroyBlock;
        }

        protected void OnBlockDamaged(Collider2D other)
        {
            var ball = other.GetColliderMonoBehaviour<BallEntity>();
            if (ball == null) return;
            
            DamageBlock(ball.BallDamage);
        }

        public bool IsDamageEnoughToDestroy(int damage)
        {
            return _lifeCount - damage <= 0;
        }
        
        public void DamageBlock(int damage)
        {
            _lifeCount -= damage;
            _cracks.UpdateBlockCracks(_lifeCount);
            if (_lifeCount <= 0)
            {
                DestroyBlock();
            }
        }

        public override void DestroyBlock()
        {
            if (_isDestroying) return;

            _isDestroying = true;
            StartCoroutine(DestroyBlockAnimate());
            EventBus.RaiseEvent<IBlockOnSceneHandler>(a => a.OnBlockStartDestroyed(this));
        }

        private IEnumerator DestroyBlockAnimate()
        {
            _sprite.ResetSprite();
            _collider.DisableCollider();
            _cracks.ResetBlockCracks();
            yield return _particles.PlayParticle();
            DestroyCompleteBlock();
        }

        protected abstract void DestroyCompleteBlock();
    }
}