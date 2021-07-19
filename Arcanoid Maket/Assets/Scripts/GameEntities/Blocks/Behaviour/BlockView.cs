using System;
using Scripts.Utils.Extensions;
using UnityEngine;

namespace GameEntities.Blocks.Behaviour
{
    public class BlockView : MonoBehaviour
    {
        public event Action<int> OnBlockDamaged;
        
        [SerializeField]
        private SpriteRenderer _spriteRenderer;
        
        [SerializeField]
        private Collider2D _collider;

        public void Initialize()
        {
            _spriteRenderer.SetTransformScaleOneByBoundsSize();
        }
        
        public void SetSprite(Sprite sprite)
        {
            _collider.enabled = true;
            _spriteRenderer.enabled = true;
            _spriteRenderer.sprite = sprite;
        }
        
        public void DisableView()
        {
            _collider.enabled = false;
            _spriteRenderer.enabled = false;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            OnBlockDamaged?.Invoke(1);
        }
    }
}