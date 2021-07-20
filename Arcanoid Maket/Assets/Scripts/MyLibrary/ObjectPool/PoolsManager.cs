using System;
using System.Collections.Generic;
using MyLibrary.ObjectPool.Abstract;
using MyLibrary.ObjectPool.Config;
using MyLibrary.Singleton;
using UnityEngine;

namespace MyLibrary.ObjectPool
{
    public class PoolsManager : Singleton<PoolsManager>
    {
        private const string PoolsConfigPath = "Data/poolsConfig";

        private Dictionary<Type, PoolContainer> _poolsMap;

        protected override void Initialize()
        {
            CreatePools();
        }

        private void CreatePools()
        {
            var config = Resources.Load<PoolsConfig>(PoolsConfigPath);
            _poolsMap = new Dictionary<Type, PoolContainer>();
            
            foreach (var creatorConfig in config.CreatorConfigs)
            {
                var creatorPrefab = creatorConfig.Creator;
                var creator = Instantiate(creatorPrefab, transform);
                creator.Initialize(creatorConfig, creator.transform);
                var container = new PoolContainer(creator);

                for (int i = 0; i < creatorConfig.InitialCount; i++)
                {
                    var instance = creator.Instantiate<PoolObject>();
                    container.PushToPool(instance);
                }
                
                _poolsMap.Add(creator.ObjectType, container);
            }
        }

        public T GetObject<T>(Vector3 position) where T : PoolObject
        {
            return GenerateObject<T>(position, Quaternion.identity, Vector3.one, null);
        }

        public T GetObject<T>(Vector3 position, Quaternion rotation) where T : PoolObject
        {
            return GenerateObject<T>(position, rotation, Vector3.one, null);
        }

        public T GetObject<T>(Vector3 position, Quaternion rotation, Vector3 scale) where T : PoolObject
        {
            return GenerateObject<T>(position, rotation, scale, null);
        }

        public T GetObject<T>(Vector3 position, Quaternion rotation, Vector3 scale, Transform parent)
            where T : PoolObject
        {
            return GenerateObject<T>(position, rotation, scale, parent);
        }

        public T GetObject<T>(Vector3 position, Transform parent) where T : PoolObject
        {
            return GenerateObject<T>(position, Quaternion.identity, Vector3.one, parent);
        }
        
        private T GenerateObject<T>(Vector3 position, Quaternion rotation, Vector3 scale, Transform parent) where T : PoolObject
        {
            var type = typeof(T);
            var go = _poolsMap[type].GetFromPool();
            var goTransform = go.transform;
            goTransform.position = position;
            goTransform.rotation = rotation;
            goTransform.localScale = scale;
            SetParent(go, parent);
            return go as T;
        }

        private void SetParent(PoolObject go, Transform parent)
        {
            go.transform.SetParent(parent);
        }

        public void ReturnObject<T>(T go) where T : PoolObject
        {
            var type = typeof(T);
            _poolsMap[type].PushToPool(go);
        }
        
        public void ReturnObject<T>(Type type, T go) where T : PoolObject
        {
            _poolsMap[type].PushToPool(go);
        }
    }
}