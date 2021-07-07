using UnityEngine;

namespace Project.Scripts.Utils.Singleton
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        protected static T _instance = null;
        public static T Instance => _instance;

        protected virtual void Awake()
        {
            if (_instance == null) 
            {
                _instance = this as T;
            } 
            else 
            {
                Destroy(gameObject);
            }
        }
    }
}