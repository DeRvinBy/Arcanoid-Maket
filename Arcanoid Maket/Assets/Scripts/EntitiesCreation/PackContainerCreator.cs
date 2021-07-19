using System;
using GameSettings.PackContainerSettings;
using Scripts.Utils.ObjectPool.Abstract;
using UI.Packs.PackItem;

namespace EntitiesCreation
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