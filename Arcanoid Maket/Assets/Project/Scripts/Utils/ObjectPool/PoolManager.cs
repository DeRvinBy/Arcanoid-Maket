using Project.Scripts.Utils.ObjectPool.Abstract;
using Project.Scripts.Utils.ObjectPool.Interfaces;
using Project.Scripts.Utils.Singleton;
using UnityEngine;

namespace Project.Scripts.Utils.ObjectPool
{
    public class PoolManager<T> : Singleton<PoolManager<T>> where T : MonoBehaviour, IPoolObject 
    {
        [SerializeField]
        private PoolObjectCreator<T> _objectCreator;

        [SerializeField]
        private int _initialSize = 0;

        private PoolContainer<T> _container;

        protected override void Awake()
        {
            base.Awake();
            CreatePool();
        }

        private void CreatePool()
        {
            _container = new PoolContainer<T>(_objectCreator);
            for (int i = 0; i < _initialSize; i++)
            {
                var instantiate = _objectCreator.Instantiate();
                instantiate.transform.gameObject.SetActive(false);
                _container.PushToPool(instantiate);
            }
        }
        
        public T GetObject(Vector3 position) =>
            GenerateObject(position, Quaternion.identity, Vector3.one, _objectCreator.transform);
        
        public T GetObject(Vector3 position, Quaternion rotation) =>
            GenerateObject(position, rotation, Vector3.one, _objectCreator.transform);
        
        public T GetObject(Vector3 position, Quaternion rotation, Vector3 scale) =>
            GenerateObject(position, rotation, scale, _objectCreator.transform);
        
        public T GetObject(Vector3 position, Quaternion rotation, Vector3 scale, Transform parent) =>
            GenerateObject(position, rotation, scale, parent);
        
        public T GetObject(Vector3 position, Transform parent) =>
            GenerateObject(position, Quaternion.identity, Vector3.one, parent);
        
        private T GenerateObject(Vector3 position, Quaternion rotation, Vector3 scale, Transform parent)
        {
            var go = _container.GetFromPool();
            var goTransform = go.transform;
            goTransform.position = position;
            goTransform.rotation = rotation;
            goTransform.localScale = scale;
            goTransform.parent = parent;
            return go;
        }

        public void ReturnObject(T go)
        {
            _container.PushToPool(go);
        }
    }
}