using Project.Scripts.GameSettings.GameBlockSettings;
using Project.Scripts.GameSettings.GameBlockSettings.Enumerations;
using Project.Scripts.MVC.Blocks.Creation;
using Project.Scripts.Utils.ObjectPool.Interfaces;
using UnityEngine;

namespace Project.Scripts.MVC.Blocks
{
    public class BlockController : MonoBehaviour, IPoolObject
    {
        [SerializeField]
        private BlockView _blockView;

        private BlockModel _blockModel;
        private MainBlockSettings _mainSettings;
        
        public void InitializeSettings(MainBlockSettings settings)
        {
            _blockModel = new BlockModel();
            _mainSettings = settings;
        }

        public void Initialize(BlockId id)
        {
            _blockModel.SetLife(_mainSettings.BlockLife);
            var settings = _mainSettings.GetBlockSettings(id);
            _blockView.SetSprite(settings.Sprite);

            _blockModel.OnBlockLifeEnded += DestroyBlock;
            _blockView.OnBlockDamaged += _blockModel.ReduceLife;
        }

        public void DestroyBlock()
        {
            BlockPoolManager.ReturnObject(this);
        }
        
        public void Setup()
        {
            
        }

        public void Reset()
        {
            
        }
    }
}