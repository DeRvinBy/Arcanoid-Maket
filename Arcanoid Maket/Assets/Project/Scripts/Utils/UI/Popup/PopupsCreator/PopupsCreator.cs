using System;
using Project.Scripts.Utils.ObjectPool.Abstract;
using Project.Scripts.Utils.UI.Popup.Abstract;

namespace Project.Scripts.Utils.UI.Popup.PopupsCreator
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