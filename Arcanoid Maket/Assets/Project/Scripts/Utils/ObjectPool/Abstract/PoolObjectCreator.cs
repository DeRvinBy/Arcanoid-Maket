using Project.Scripts.Utils.ObjectPool.Interfaces;
using UnityEngine;

namespace Project.Scripts.Utils.ObjectPool.Abstract
{
    public abstract class PoolObjectCreator<T> : MonoBehaviour where T : MonoBehaviour, IPoolObject
    {
        [SerializeField]
        protected T _prefab = null;

        public abstract T Instantiate();
    }
}