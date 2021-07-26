using System;
using GameEntities.Bonuses;
using GameSettings.GameBonusSettings;
using GameSettings.GameBonusSettings.ObjectSettings;
using MyLibrary.ObjectPool.Abstract;
using MyLibrary.ObjectPool.Config;
using UnityEngine;

namespace EntitiesCreation
{
    public class BonusObjectCreator : PoolObjectCreator<BonusObject, BonusObjectSettings>
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