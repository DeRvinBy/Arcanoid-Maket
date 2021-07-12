using System.Collections;
using Project.Scripts.EntitiesCreation.BlockCreation;
using Project.Scripts.EventInterfaces.BlockEvents;
using Project.Scripts.GameEntities.Blocks.Components;
using Project.Scripts.GameEntities.Blocks.Enumerations;
using Project.Scripts.GameSettings.GameBlockSettings;
using Project.Scripts.Utils.EventSystem;
using Project.Scripts.Utils.ObjectPool.Interfaces;
using UnityEngine;

namespace Project.Scripts.GameEntities.Blocks
{
    public class BlockEntity : MonoBehaviour, IPoolObject
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

        public void Setup()
        {
            _view.OnBlockDamaged += ReduceLifeCount;

            EventBus.RaiseEvent<IBlockOnSceneHandler>(a => a.OnBlockCreated(this));
        }

        public void Reset()
        {
            _view.OnBlockDamaged -= ReduceLifeCount;
        }
        
        private void ReduceLifeCount(int reducingCount)
        {
            _lifeCount -= reducingCount;
            _cracks.UpdateBlockCracks(_lifeCount);
            if (_lifeCount > 0) return;
            
            StartCoroutine(DestroyBlock());
            EventBus.RaiseEvent<IBlockOnSceneHandler>(a => a.OnBlockDestroyed(this));
        }

        private IEnumerator DestroyBlock()
        {
            _view.DisableView();
            _cracks.DisableBlockCracks();
            _particles.PlayParticle();
            yield return new WaitWhile(() => _particles.IsParticlesPlaying);
            BlockPoolManager.Instance.ReturnObject(this);
        }
    }
}