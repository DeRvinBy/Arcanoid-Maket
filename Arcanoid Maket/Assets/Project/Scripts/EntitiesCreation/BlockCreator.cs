using System;
using Project.Scripts.GameEntities.Blocks;
using Project.Scripts.GameSettings.GameBlockSettings;
using Project.Scripts.Utils.ObjectPool.Abstract;
using Project.Scripts.Utils.ObjectPool.Config;
using UnityEngine;

namespace Project.Scripts.EntitiesCreation
{
    public class BlockCreator : PoolObjectCreator<BlockEntity, MainBlockSettings>
    {
        public override void Initialize(ObjectCreatorConfig<PoolObject, AbstractCreator, AbstractSettings> config, Transform parent)
        {
            base.Initialize(config, parent);
            _settings.Initialize();
        }

        public override Type ObjectType => typeof(BlockEntity);
        public override PoolObject Instantiate<T>()
        {
            var instance = Instantiate(_prefab, _parent);
            instance.Initialize(_settings);
            return instance;
        }
    }
}