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

        public void Initialize()
        {
            _spriteRenderer.SetTransformScaleOneByBoundsSize();
        }
        
        public void SetSprite(Sprite sprite)
        {
            _spriteRenderer.sprite = sprite;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            print(other.gameObject.name);
            OnBlockDamaged?.Invoke(1);
        }
    }
}