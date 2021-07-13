using System;
using System.Collections.Generic;
using Project.Scripts.Utils.ObjectPool.Abstract;
using Project.Scripts.Utils.ObjectPool.Config;
using Project.Scripts.Utils.Singleton;
using UnityEngine;

namespace Project.Scripts.Utils.ObjectPool
{
    public class PoolsManager : Singleton<PoolsManager>
    {
        private const string PoolsConfigPath = "Data/pools_config";
        private const string CreatorsPrefabsPathFormat = "Prefabs/{0}";
            
        private Dictionary<Type, PoolContainer> _poolsMap;
        private Dictionary<Type, PoolObjectCreator<PoolObject>> _creatorsMap;

        protected override void Awake()
        {
            base.Awake();
            CreatePool();
        }

        private void CreatePool()
        {
            var configs = Resources.Load<PoolsConfig>(PoolsConfigPath).CreatorConfigs;
            _poolsMap = new Dictionary<Type, PoolContainer>();
            _creatorsMap = new Dictionary<Type, PoolObjectCreator<PoolObject>>();

            foreach (var config in configs)
            {
                var path = string.Format(CreatorsPrefabsPathFormat, config.CreatorPrefabName);
                var creatorPrefab = Resources.Load<GameObject>(path); 
                var creator = Instantiate(creatorPrefab, transform).GetComponent<PoolObjectCreator<PoolObject>>();
                var type = creator.ObjectType;
                var container = new PoolContainer(creator);
                _poolsMap.Add(type, container);
                _creatorsMap.Add(type, creator);
            }
        }

        public T GetObject<T>(Vector3 position) where T : PoolObject
        {
            return GenerateObject<T>(position, Quaternion.identity, Vector3.one);
        }

        public T GetObject<T>(Vector3 position, Quaternion rotation) where T : PoolObject
        {
            return GenerateObject<T>(position, rotation, Vector3.one);
        }

        public T GetObject<T>(Vector3 position, Quaternion rotation, Vector3 scale) where T : PoolObject
        {
            return GenerateObject<T>(position, rotation, scale);
        }

        public T GetObject<T>(Vector3 position, Quaternion rotation, Vector3 scale, Transform parent)
            where T : PoolObject
        {
            var go = GenerateObject<T>(position, rotation, scale);
            SetParent(go, parent);
            return go;
        }

        public T GetObject<T>(Vector3 position, Transform parent) where T : PoolObject
        {
            var go = GenerateObject<T>(position, Quaternion.identity, Vector3.one);
            SetParent(go, parent);
            return go;
        }
        
        private T GenerateObject<T>(Vector3 position, Quaternion rotation, Vector3 scale) where T : PoolObject
        {
            var type = typeof(T);
            var go = _poolsMap[type].GetFromPool();
            var goTransform = go.transform;
            goTransform.position = position;
            goTransform.rotation = rotation;
            goTransform.localScale = scale;
            return go as T;
        }

        private void SetParent(PoolObject go, Transform parent)
        {
            go.transform.parent = parent;
        }

        public void ReturnObject<T>(T go) where T : PoolObject
        {
            var type = typeof(T);
            go.transform.parent = _creatorsMap[type].transform;
            _poolsMap[type].PushToPool(go);
        }
    }
}