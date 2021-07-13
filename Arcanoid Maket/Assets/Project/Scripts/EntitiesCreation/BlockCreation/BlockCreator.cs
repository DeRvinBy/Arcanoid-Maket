using Project.Scripts.GameEntities.Blocks;
using Project.Scripts.GameSettings.GameBlockSettings;
using Project.Scripts.Utils.ObjectPool.Abstract;
using UnityEngine;

namespace Project.Scripts.EntitiesCreation.BlockCreation
{
    public class BlockCreator : PoolObjectCreator<BlockEntity>
    {
        [SerializeField]
        private MainBlockSettings _blockSettings;

        public override BlockEntity Instantiate()
        {
            var instance = Instantiate(_prefab, transform);
            instance.Initialize(_blockSettings);
            return instance;
        }
    }
}