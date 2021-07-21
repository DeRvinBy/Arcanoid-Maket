using MyLibrary.Extensions;
using UnityEngine;

namespace GameEntities.Blocks.Components
{
    public class BlockSprite : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        public void Initialize()
        {
            _spriteRenderer.SetTransformScaleOneByBoundsSize();
        }

        public void SetupSprite(Sprite sprite)
        {
            _spriteRenderer.enabled = true;
            _spriteRenderer.sprite = sprite;
        }

        public void ResetSprite()
        {
            _spriteRenderer.enabled = false;
        }
    }
}