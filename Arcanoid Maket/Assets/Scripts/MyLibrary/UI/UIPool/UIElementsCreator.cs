using System;
using MyLibrary.ObjectPool.Abstract;

namespace MyLibrary.UI.UIPool
{
    public class UIElementsCreator : PoolObjectCreator<UIElementPoolObject, UIElementsPoolObjectSettings>
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