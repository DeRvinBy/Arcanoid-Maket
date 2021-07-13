using System;
using UnityEngine;

namespace Project.Scripts.Utils.ObjectPool.Abstract
{
    public abstract class PoolObjectCreator<T> : MonoBehaviour where T : PoolObject
    {
        [SerializeField]
        protected T _prefab;

        public Type ObjectType => typeof(T);
        
        public abstract T Instantiate();
    }
}