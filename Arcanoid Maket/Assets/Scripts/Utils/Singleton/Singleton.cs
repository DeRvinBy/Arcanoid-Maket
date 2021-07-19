using UnityEngine;

namespace Scripts.Utils.Singleton
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        private  static T _instance = null;
        public static T Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }

                var singletons = FindObjectsOfType<T>();
                if (singletons != null)
                {
                    if (singletons.Length == 1)
                    {
                        _instance = singletons[0];
                        DontDestroyOnLoad(_instance);
                        return _instance;
                    }
                        
                    if(singletons.Length > 1)
                    {
                        for (int i = 0; i < singletons.Length; ++i)
                        {
                            var singleton = singletons[i];
                            Destroy(singleton.gameObject);
                        }
                    }
                }
                    
                var go = new GameObject(typeof(T).Name, typeof(T));
                DontDestroyOnLoad(go);
                return _instance;
            }
        }

        protected void Awake()
        {
            if (_instance == null)
            {
                DontDestroyOnLoad(gameObject);
                _instance = this as T;
                Initialize();
            }
            else
            {
                Debug.LogWarning($"[SINGLETON] Have more that one {typeof(T).Name} in scene.");
                DestroyImmediate(gameObject);
            }
        }
        
        protected virtual void Initialize() { }
    }
}