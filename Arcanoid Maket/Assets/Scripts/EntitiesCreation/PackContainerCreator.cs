using System;
using Scripts.GameSettings.PackContainerSettings;
using Scripts.UI.Packs.PackItem;
using Scripts.Utils.ObjectPool.Abstract;

namespace Scripts.EntitiesCreation
{
    public class PackContainerCreator : 
        PoolObjectCreator<PackContainerEntity, DefaultPackContainerSettings>
    {
        public override Type ObjectType => typeof(PackContainerEntity);
        public override PoolObject Instantiate<T>()
        {
            var instance = Instantiate(_prefab, _parent);
            instance.Initialize(_settings);
            return instance;
        }
    }
}