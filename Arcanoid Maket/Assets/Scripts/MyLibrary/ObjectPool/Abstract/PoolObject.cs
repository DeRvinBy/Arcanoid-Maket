using UnityEngine;

namespace MyLibrary.ObjectPool.Abstract
{
    public abstract class PoolObject : MonoBehaviour
    {
        public virtual void Setup()
        {
            gameObject.SetActive(true);
        }
        
        public virtual void Reset()
        {
            gameObject.SetActive(false);
        }
    }
}