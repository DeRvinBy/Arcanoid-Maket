using System;
using MyLibrary.CollisionStorage.Colliders2D;
using UnityEngine;

namespace GameEntities.Blocks.Components
{
    public class BlockCollider : CollisionCollider2D
    {
        public event Action OnTriggerEnter;
        
        public void EnableTrigger()
        {
            _collider.isTrigger = true;
        }

        public void DisableTrigger()
        {
            _collider.isTrigger = false;
        }
        
        public void EnableCollider()
        {
            _collider.enabled = true;
        }
        
        public void DisableCollider()
        {
            _collider.enabled = false;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            OnTriggerEnter?.Invoke();
        }
    }
}