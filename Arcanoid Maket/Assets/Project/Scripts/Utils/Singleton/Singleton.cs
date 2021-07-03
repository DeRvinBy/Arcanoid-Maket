using UnityEngine;

namespace Project.Scripts.Utils.Singleton
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        protected static T _instance;
        
        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
            }

            _instance = this as T;
            OnAwake();
        }
        
        protected virtual void OnAwake() { }
    }
}