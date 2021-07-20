using System;
using GameEntities.Blocks.Abstract;
using GameSettings.GameBlockSettings;
using MyLibrary.ObjectPool.Abstract;
using MyLibrary.ObjectPool.Config;
using UnityEngine;

namespace EntitiesCreation
{
    public class BlockCreator : PoolObjectCreator<AbstractBlock, BlockSettings>
    {
        public override void Initialize(ObjectCreatorConfig<PoolObject, AbstractCreator, AbstractSettings> config, Transform parent)
        {
            base.Initialize(config, parent);
            _settings.Initialize();
        }

        public override Type ObjectType => _prefab.GetType();
        public override PoolObject Instantiate<T>()
        {
            var instance = Instantiate(_prefab, _parent);
            instance.Initialize(_settings);
            return instance;
        }
    }
}