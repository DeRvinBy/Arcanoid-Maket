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

        public void SetSprite(Sprite sprite)
        {
            _spriteRenderer.sprite = sprite;
            _spriteRenderer.SetTransformScaleOneByBoundsSize();
        }

        private void OnCollisionEnter(Collision other)
        {
            OnBlockDamaged?.Invoke(1);
        }
    }
}