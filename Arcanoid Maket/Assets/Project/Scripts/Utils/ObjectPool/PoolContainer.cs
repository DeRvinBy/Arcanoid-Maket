using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Project.Scripts.Utils.ObjectPool
{
    [Serializable]
    public class PoolContainer
    {
        public PoolSettings PoolSettings;

        private Stack<GameObject> _container;
        private Transform _parent;

        public void CreatePool(Transform parent)
        {
            _parent = parent;
            _container = new Stack<GameObject>();

            for (int i = 0; i < PoolSettings.InitialCount; i++)
            {
                var go = InstantiateObject();
                _container.Push(go);
            }
        }
        
        public void ReturnToPool(GameObject gameObject)
        {
            gameObject.SetActive(false);
            _container.Push(gameObject);
        }

        public GameObject GetFromPool()
        {
            var result = _container.Count == 0 ? InstantiateObject() : _container.Pop();
            result.SetActive(true);
            return result;
        }
        
        private GameObject InstantiateObject()
        {
            var gameObject = Object.Instantiate(PoolSettings.Prefab, _parent);
            gameObject.name = PoolSettings.Prefab.name;
            gameObject.SetActive(false);
            return gameObject;
        }
    }
}