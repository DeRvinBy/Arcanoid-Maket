using System;
using GameSettings.LifeSettings;
using Library.ObjectPool.Abstract;
using UI.Header.LifeUI;

namespace EntitiesCreation
{
    public class LifeImageUICreator : PoolObjectCreator<LifeImageUI, LifeImageSettings>
    {
        public override Type ObjectType => typeof(LifeImageUI);
        public override PoolObject Instantiate<T>()
        {
            var instance = Instantiate(_prefab, _parent);
            return instance;
        }
    }
}