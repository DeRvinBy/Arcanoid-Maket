using System;
using UnityEngine;

namespace GameEntities.Blocks.Components
{
    public class BlockCollider : MonoBehaviour
    {
        public event Action<Collision2D> OnBlockCollided;

        [SerializeField]
        private Collider2D _collider;
        
        public void SetupCollider()
        {
            _collider.enabled = true;
        }
        
        public void ResetCollider()
        {
            _collider.enabled = false;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            OnBlockCollided?.Invoke(other);
        }
    }
}