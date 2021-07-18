using System;
using Scripts.GameEntities.Ball;
using Scripts.GameSettings.GameBallSettings;
using Scripts.Utils.ObjectPool.Abstract;

namespace Scripts.EntitiesCreation
{
    public class BallCreator : PoolObjectCreator<BallEntity, BallSettings>
    {
        public override Type ObjectType => typeof(BallEntity);
        public override PoolObject Instantiate<T>()
        {
            var instance = Instantiate(_prefab, _parent);
            instance.Initialize(_settings);
            return instance;
        }
    }
}