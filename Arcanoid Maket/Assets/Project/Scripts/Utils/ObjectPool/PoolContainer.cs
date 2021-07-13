using System.Collections.Generic;
using Project.Scripts.Utils.ObjectPool.Abstract;

namespace Project.Scripts.Utils.ObjectPool
{
    public class PoolContainer
    {
        private Stack<PoolObject> _container;
        private PoolObjectCreator<PoolObject> _poolObjectCreator;

        public PoolContainer(PoolObjectCreator<PoolObject> creator)
        {
            _poolObjectCreator = creator;
            _container = new Stack<PoolObject>();
        }

        public void PushToPool(PoolObject obj)
        {
            obj.Reset();
            _container.Push(obj);
        }

        public PoolObject GetFromPool()
        {
            var result = _container.Count == 0 ? _poolObjectCreator.Instantiate() : _container.Pop();
            result.Setup();
            return result;
        }
    }
}