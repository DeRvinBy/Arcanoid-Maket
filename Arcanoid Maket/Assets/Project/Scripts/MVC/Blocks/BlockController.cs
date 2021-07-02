using Project.Scripts.GameSettings.GameBlockSettings;
using Project.Scripts.MVC.Blocks.Creation;
using Project.Scripts.MVC.Blocks.Enumerations;
using Project.Scripts.Utils.ObjectPool.Interfaces;
using UnityEngine;

namespace Project.Scripts.MVC.Blocks
{
    public class BlockController : MonoBehaviour, IPoolObject
    {
        [SerializeField]
        private BlockView _view;

        private BlockModel _model;
        private MainBlockSettings _mainSettings;
        private BlockId _currentId;
        
        public void Initialize(MainBlockSettings settings)
        {
            _model = new BlockModel();
            _mainSettings = settings;
        }

        public void SetBlockId(BlockId id)
        {
            _currentId = id;
        }

        public void Setup()
        {
            _model.SetLife(_mainSettings.BlockLife);
            var settings = _mainSettings.GetBlockSettings(_currentId);
            _view.SetSprite(settings.Sprite);

            _model.OnBlockLifeEnded += DestroyBlock;
            _view.OnBlockDamaged += _model.ReduceLife;
        }
        
        private void DestroyBlock()
        {
            BlockPoolManager.ReturnObject(this);
        }

        public void Reset()
        {
            _model.OnBlockLifeEnded -= DestroyBlock;
            _view.OnBlockDamaged -= _model.ReduceLife;
        }
    }
}