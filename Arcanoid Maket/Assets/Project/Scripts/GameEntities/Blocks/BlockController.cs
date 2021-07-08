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
    public class BlockController : MonoBehaviour, IPoolObject
    {
        private const int DestroyLifeCount = 0;
        
        [SerializeField]
        private BlockView _view;

        [SerializeField]
        private BlockCracks _cracks;

        [SerializeField]
        private BlockParticles _particles;

        private BlockModel _model;
        private MainBlockSettings _mainSettings;

        public void Initialize(MainBlockSettings settings)
        {
            _mainSettings = settings;
            _model = new BlockModel();
            _view.Initialize();
            _model.Initialize(settings.LifeSettings);
            _cracks.Initialize(settings.LifeSettings);
        }

        public void SetupBlock(BlockId id)
        {
            var settings = _mainSettings.GetBlockSettings(id);
            _view.SetSprite(settings.Sprite);
            _particles.SetParticleColor(settings.ParticleColor);
            _model.SetupModel();
            _cracks.SetupBlockCracks();
        }

        public void Setup()
        {
            _view.OnBlockDamaged += _model.ReduceLife;
            _model.OnBlockLifeChanged += DestroyBlock;
            _model.OnBlockLifeChanged += _cracks.UpdateBlockCracks;
            
            EventBus.RaiseEvent<IBlockOnSceneHandler>(a => a.OnBlockCreated(this));
        }

        public void Reset()
        {
            _view.OnBlockDamaged -= _model.ReduceLife;
            _model.OnBlockLifeChanged -= DestroyBlock;
            _model.OnBlockLifeChanged -= _cracks.UpdateBlockCracks;
        }
        
        private void DestroyBlock(int life)
        {
            if (life <= DestroyLifeCount)
            {
                _cracks.DisableBlockCracks();
                StartCoroutine(DestroyBlockAfterParticles());
                EventBus.RaiseEvent<IBlockOnSceneHandler>(a => a.OnBlockDestroyed(this));
            }
        }

        private IEnumerator DestroyBlockAfterParticles()
        {
            _view.DisableView();
            _particles.PlayParticle();
            yield return new WaitWhile(() => _particles.IsParticlesPlaying);
            BlockPoolManager.Instance.ReturnObject(this);
        }
    }
}