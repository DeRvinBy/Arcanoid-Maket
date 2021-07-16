using System;
using Project.Scripts.GameSettings.PackContainerSettings;
using Project.Scripts.UI.Packs;
using Project.Scripts.Utils.ObjectPool.Abstract;

namespace Project.Scripts.EntitiesCreation
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