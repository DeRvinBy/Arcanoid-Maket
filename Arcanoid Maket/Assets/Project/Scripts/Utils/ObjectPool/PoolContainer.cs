using System.Collections.Generic;
using Project.Scripts.Utils.Extensions;
using Project.Scripts.Utils.ObjectPool.Abstract;
using Project.Scripts.Utils.ObjectPool.Interfaces;
using UnityEngine;

namespace Project.Scripts.Utils.ObjectPool
{
    public class PoolContainer<T> where T : MonoBehaviour, IPoolObject
    {
        private Stack<T> _container;
        private PoolObjectCreator<T> _objectCreator;

        public PoolContainer(PoolObjectCreator<T> creator)
        {
            _objectCreator = creator;
            _container = new Stack<T>();
        }

        public void PushToPool(T obj)
        {
            obj.Reset();
            obj.SetActive(false);
            obj.transform.parent = _objectCreator.transform;
            _container.Push(obj);
        }

        public T GetFromPool()
        {
            var result = _container.Count == 0 ? _objectCreator.Instantiate() : _container.Pop();
            result.SetActive(true);
            result.Setup();
            return result;
        }
    }
}