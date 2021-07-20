using System;
using MyLibrary.ObjectPool.Abstract;
using MyLibrary.UI.Popup.Abstract;

namespace MyLibrary.UI.Popup.PopupsCreator
{
    public class PopupsCreator : PoolObjectCreator<AbstractPopup, PopupSettings>
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