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
            _model = new BlockModel();
            _mainSettings = settings;
            _view.Initialize();
            _cracks.Initialize(settings.LifeSettings);
        }

        public void SetupBlock(BlockId id)
        {
            _model.SetLife(_mainSettings.LifeSettings.BlockLife);
            var settings = _mainSettings.GetBlockSettings(id);
            _view.SetSprite(settings.Sprite);
            _particles.SetParticleColor(settings.ParticleColor);
            _cracks.SetupBlockCracks();
        }

        public void Setup()
        {
            _view.OnBlockDamaged += _model.ReduceLife;
            _model.OnBlockLifeChanged += DestroyBlock;
            _model.OnBlockLifeChanged += _cracks.UpdateBlockCracks;
        }
        
        private void DestroyBlock(int life)
        {
            if (life <= 0)
            {
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

        public void Reset()
        {
            _view.OnBlockDamaged -= _model.ReduceLife;
            _model.OnBlockLifeChanged -= DestroyBlock;
            _model.OnBlockLifeChanged -= _cracks.UpdateBlockCracks;
        }
    }
}