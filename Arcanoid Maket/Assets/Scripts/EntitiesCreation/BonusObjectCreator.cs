using System;
using GameEntities.Bonuses;
using GameSettings.GameBonusSettings;
using MyLibrary.ObjectPool.Abstract;

namespace EntitiesCreation
{
    public class BonusObjectCreator : PoolObjectCreator<BonusObject, BonusObjectSettings>
    {
        public override Type ObjectType => _prefab.GetType();
        public override PoolObject Instantiate<T>()
        {
            var instance = Instantiate(_prefab, _parent);
            instance.Initialize();
            return instance;
        }
    }
}