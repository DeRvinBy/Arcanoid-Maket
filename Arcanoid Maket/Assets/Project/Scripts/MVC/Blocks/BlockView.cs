using System;
using Project.Scripts.Utils.Extensions;
using UnityEngine;

namespace Project.Scripts.MVC.Blocks
{
    public class BlockView : MonoBehaviour
    {
        public Action<int> OnBlockDamaged;
        
        [SerializeField]
        private SpriteRenderer _spriteRenderer = null;
        
        [SerializeField]
        private Collider2D _collider = null;

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