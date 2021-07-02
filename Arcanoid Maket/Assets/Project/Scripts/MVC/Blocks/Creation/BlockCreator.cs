using Project.Scripts.GameSettings.GameBlockSettings;
using Project.Scripts.Utils.ObjectPool.Abstract;
using UnityEngine;

namespace Project.Scripts.MVC.Blocks.Creation
{
    public class BlockCreator : PoolObjectCreator<BlockController>
    {
        [SerializeField]
        private MainBlockSettings _blockSettings = null;
        
        public override BlockController Instantiate()
        {
            var instance = Instantiate(_prefab, transform);
            instance.Initialize(_blockSettings);
            return instance;
        }
    }
}