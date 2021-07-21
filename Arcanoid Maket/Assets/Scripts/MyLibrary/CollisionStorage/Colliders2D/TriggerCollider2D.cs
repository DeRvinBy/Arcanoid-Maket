using System;
using UnityEngine;

namespace MyLibrary.CollisionStorage.Colliders2D
{
    public class TriggerCollider2D : GeneralCollider2D
    {
        public event Action<Collider2D> OnTriggerEnter;
        public event Action<Collider2D> OnTriggerStay;
        public event Action<Collider2D> OnTriggerExit;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            OnTriggerEnter?.Invoke(other);
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            OnTriggerStay?.Invoke(other);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            OnTriggerExit?.Invoke(other);
        }
    }
}