using System.Collections.Generic;
using MyLibrary.ObjectPool.Abstract;

namespace MyLibrary.ObjectPool
{
    public class PoolContainer
    {
        private Stack<PoolObject> _container;
        private AbstractCreator _objectCreator;

        public PoolContainer(AbstractCreator creator)
        {
            _objectCreator = creator;
            _container = new Stack<PoolObject>();
        }

        public void PushToPool(PoolObject obj)
        {
            obj.OnReset();
            obj.transform.SetParent(_objectCreator.Parent);
            _container.Push(obj);
        }

        public PoolObject GetFromPool()
        {
            var result = _container.Count == 0 ? _objectCreator.Instantiate<PoolObject>() : _container.Pop();
            result.OnSetup();
            return result;
        }
    }
}