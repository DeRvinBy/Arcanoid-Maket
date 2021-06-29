using System.Collections.Generic;
using Project.Scripts.Utils.ObjectPool.Enumerations;
using UnityEngine;

namespace Project.Scripts.Utils.ObjectPool
{
    public class PoolManager : MonoBehaviour
    {
        private static PoolManager _instance;
        
        [SerializeField]
        private List<PoolContainer> _poolsContainers = null;

        private Dictionary<ObjectPoolType, PoolContainer> _pools;

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
            }

            _instance = this;
            
            CreatePools();
        }

        private void CreatePools()
        {
            _pools = new Dictionary<ObjectPoolType, PoolContainer>();
            var _transform = transform;
            foreach (var container in _poolsContainers)
            {
                Debug.Log(container);
                var type = container.PoolSettings._type;
                var parent = new GameObject(type.ToString());
                parent.transform.parent = _transform;
                container.CreatePool(_transform);
                _pools.Add(type, container);
            }
        }

        public static GameObject GetObject(ObjectPoolType type, Vector3 position) =>
            _instance.GenerateObject(type, position, Quaternion.identity);
        
        public static GameObject GetObject(ObjectPoolType type, Vector3 position, Quaternion rotation) =>
            _instance.GenerateObject(type, position, Quaternion.identity);

        private GameObject GenerateObject(ObjectPoolType type, Vector3 position, Quaternion rotation)
        {
            var go = _pools[type].GetFromPool();
            go.transform.position = position;
            go.transform.rotation = rotation;
            return go;
        }

        public static void ReturnObject(ObjectPoolType type, GameObject go) => 
            _instance.ReturnObjectToPool(type, go);

        private void ReturnObjectToPool(ObjectPoolType type, GameObject go)
        {
            _pools[type].ReturnToPool(go);
        }
    }
}