using System;
using UnityEngine;

namespace MyLibrary.CollisionStorage.Colliders2D
{
    public class CollisionCollider2D : GeneralCollider2D
    {
        public event Action<Collider2D> OnCollisionEnter;
        public event Action<Collider2D> OnCollisionStay;
        public event Action<Collider2D> OnCollisionExit;

        private void OnCollisionEnter2D(Collision2D other)
        {
            OnCollisionEnter?.Invoke(other.collider);
        }
        
        private void OnCollisionStay2D(Collision2D other)
        {
            OnCollisionStay?.Invoke(other.collider);
        }
        
        private void OnCollisionExit2D(Collision2D other)
        {
            OnCollisionExit?.Invoke(other.collider);
        }
    }
}