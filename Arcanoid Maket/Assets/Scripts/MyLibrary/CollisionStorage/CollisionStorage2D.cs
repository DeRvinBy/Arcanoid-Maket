using System;
using System.Collections.Generic;
using MyLibrary.Singleton;
using UnityEngine;

namespace MyLibrary.CollisionStorage
{
    public class CollisionStorage2D : Singleton<CollisionStorage2D>
    {
        private Dictionary<Type, List<Collider2D>> _collidersMap;
        private Dictionary<Collider2D, MonoBehaviour> _monoBehavioursMap;

        protected override void Initialize()
        {
            base.Initialize();
            _collidersMap = new Dictionary<Type, List<Collider2D>>();
            _monoBehavioursMap = new Dictionary<Collider2D, MonoBehaviour>();
        }

        public void RegisterCollider<T>(Collider2D monoCollider, T monoBehaviour) where T : MonoBehaviour
        {
            var type = typeof(T);
            if (!_collidersMap.ContainsKey(type))
            {
                _collidersMap.Add(type, new List<Collider2D>());
            }
            _collidersMap[type].Add(monoCollider);
            _monoBehavioursMap[monoCollider] = monoBehaviour;
        }

        public void UnregisterCollider<T>(Collider2D monoCollider, T monoBehaviour) where T : MonoBehaviour
        {
            var type = typeof(T);
            if (!_collidersMap.ContainsKey(type)) return;
            
            _collidersMap[type].Remove(monoCollider);
        }

        public bool IsColliderHasMonoBehaviour<T>(Collider2D monoCollider) where T : MonoBehaviour
        {
            if (!_collidersMap.ContainsKey(typeof(T))) return false;

            return _collidersMap[typeof(T)].Contains(monoCollider);
        }
        
        public T GetColliderMonoBehaviour<T>(Collider2D monoCollider) where T : MonoBehaviour
        {
            var type = typeof(T);
            if (!_collidersMap.ContainsKey(type)) return null;

            return _monoBehavioursMap[monoCollider] as T;
        }
    }
}