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

        protected override void OnAwake()
        {
            CreatePools();
        }

        private void CreatePools()
        {
            _container = new PoolContainer<T>(_objectCreator);
            for (int i = 0; i < _initialSize; i++)
            {
                var instantiate = _objectCreator.Instantiate();
                instantiate.transform.gameObject.SetActive(false);
                _container.PushToPool(instantiate);
            }
        }
        
        public static T GetObject(Vector3 position) =>
            _instance.GenerateObject(position, Quaternion.identity);
        
        public static T GetObject(Vector3 position, Quaternion rotation) =>
            _instance.GenerateObject(position, Quaternion.identity);
        
        private T GenerateObject(Vector3 position, Quaternion rotation)
        {
            var go = _container.GetFromPool();
            var goTransform = go.transform;
            goTransform.position = position;
            goTransform.rotation = rotation;
            return go;
        }
        
        public static void ReturnObject(T go) => 
            _instance.ReturnObjectToPool(go);
        
        private void ReturnObjectToPool(T go)
        {
            _container.PushToPool(go);
        }
    }
}