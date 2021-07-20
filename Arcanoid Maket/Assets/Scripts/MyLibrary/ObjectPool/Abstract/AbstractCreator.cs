using System;
using MyLibrary.ObjectPool.Config;
using UnityEngine;

namespace MyLibrary.ObjectPool.Abstract
{
    public abstract class AbstractCreator : MonoBehaviour
    {
        public abstract void Initialize(ObjectCreatorConfig<PoolObject, AbstractCreator, AbstractSettings> config,
            Transform parent);
        
        public abstract Type ObjectType { get; }
        public abstract Transform Parent { get; }
        public abstract PoolObject Instantiate<T>();
    }
}