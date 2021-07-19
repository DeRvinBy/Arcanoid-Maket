using System;
using Scripts.GameSettings.LifeSettings;
using Scripts.UI.Header.LifeUI;
using Scripts.Utils.ObjectPool.Abstract;

namespace Scripts.EntitiesCreation
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