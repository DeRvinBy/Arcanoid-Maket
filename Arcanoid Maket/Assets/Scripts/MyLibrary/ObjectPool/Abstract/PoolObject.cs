using UnityEngine;

namespace MyLibrary.ObjectPool.Abstract
{
    public abstract class PoolObject : MonoBehaviour
    {
        public virtual void OnSetup()
        {
            gameObject.SetActive(true);
        }
        
        public virtual void OnReset()
        {
            gameObject.SetActive(false);
        }
    }
}