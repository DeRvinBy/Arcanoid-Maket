using System;
using Project.Scripts.GameEntities.Ball;
using Project.Scripts.GameSettings.GameBallSettings;
using Project.Scripts.Utils.ObjectPool.Abstract;

namespace Project.Scripts.EntitiesCreation
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