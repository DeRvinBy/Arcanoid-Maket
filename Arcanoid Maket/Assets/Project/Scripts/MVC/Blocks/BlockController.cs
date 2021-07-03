using System.Collections;
using Project.Scripts.GameSettings.GameBlockSettings;
using Project.Scripts.MVC.Blocks.Creation;
using Project.Scripts.MVC.Blocks.Enumerations;
using Project.Scripts.MVC.Blocks.GameComponents;
using Project.Scripts.Utils.ObjectPool.Interfaces;
using UnityEngine;

namespace Project.Scripts.MVC.Blocks
{
    public class BlockController : MonoBehaviour, IPoolObject
    {
        private const int DestroyLifeCount = 1;
        
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
            }
        }

        private IEnumerator DestroyBlockAfterParticles()
        {
            _view.DisableView();
            _particles.PlayParticle();
            yield return new WaitWhile(() => _particles.IsParticlesPlaying);
            BlockPoolManager.ReturnObject(this);
        }
    }
}