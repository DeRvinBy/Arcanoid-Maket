using System.Collections.Generic;
using Project.Scripts.Utils.ObjectPool.Abstract;

namespace Project.Scripts.Utils.ObjectPool
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
            obj.Reset();
            obj.transform.SetParent(_objectCreator.Parent);
            _container.Push(obj);
        }

        public PoolObject GetFromPool()
        {
            var result = _container.Count == 0 ? _objectCreator.Instantiate<PoolObject>() : _container.Pop();
            result.Setup();
            return result;
        }
    }
}