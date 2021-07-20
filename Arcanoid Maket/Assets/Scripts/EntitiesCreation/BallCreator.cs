using System;
using GameEntities.Ball;
using GameSettings.GameBallSettings;
using MyLibrary.ObjectPool.Abstract;

namespace EntitiesCreation
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