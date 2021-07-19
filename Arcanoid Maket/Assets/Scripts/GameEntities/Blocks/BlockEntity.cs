using System.Collections;
using EventInterfaces.BlockEvents;
using GameEntities.Blocks.Behaviour;
using GameEntities.Blocks.Enumerations;
using GameSettings.GameBlockSettings;
using Library.EventSystem;
using Library.ObjectPool.Abstract;
using UnityEngine;

namespace GameEntities.Blocks
{
    public class BlockEntity : PoolObject
    {
        [SerializeField]
        private BlockView _view;

        [SerializeField]
        private BlockCracks _cracks;

        [SerializeField]
        private BlockParticles _particles;

        private int _lifeCount;
        private MainBlockSettings _mainSettings;

        public void Initialize(MainBlockSettings settings)
        {
            _mainSettings = settings;
            
            _view.Initialize();
            _cracks.Initialize(settings.LifeSettings);
        }

        public void SetupBlock(BlockId id)
        {
            _lifeCount = _mainSettings.LifeSettings.BlockLife;
            var settings = _mainSettings.GetBlockSettings(id);
            _view.SetSprite(settings.Sprite);
            _particles.SetParticleColor(settings.ParticleColor);
            _cracks.SetupBlockCracks();
        }

        public override void Setup()
        {
            base.Setup();
            _view.OnBlockDamaged += ReduceLifeCount;
        }

        public override void Reset()
        {
            base.Reset();
            _view.OnBlockDamaged -= ReduceLifeCount;
        }
        
        private void ReduceLifeCount(int reducingCount)
        {
            _lifeCount -= reducingCount;
            _cracks.UpdateBlockCracks(_lifeCount);
            if (_lifeCount <= 0)
            {
                StartCoroutine(DestroyBlock());
                EventBus.RaiseEvent<IBlockOnSceneHandler>(a => a.OnBlockStartDestroyed());    
            }
        }

        private IEnumerator DestroyBlock()
        {
            _view.DisableView();
            _cracks.DisableBlockCracks();
            _particles.PlayParticle();
            yield return new WaitWhile(() => _particles.IsParticlesPlaying);
            EventBus.RaiseEvent<IBlockOnSceneHandler>(a => a.OnDestroyBlock(this));
        }
    }
}