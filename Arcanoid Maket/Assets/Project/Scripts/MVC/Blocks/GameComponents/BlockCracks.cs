using Project.Scripts.GameSettings.GameBlockSettings;
using Project.Scripts.Utils.Extensions;
using UnityEngine;

namespace Project.Scripts.MVC.Blocks.GameComponents
{
    public class BlockCracks : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _spriteRenderer = null;

        private BlockLifeSettings _lifeSettings;

        public void Initialize(BlockLifeSettings settings)
        {
            _lifeSettings = settings;
            _spriteRenderer.SetTransformScaleOneByBoundsSize();
        }

        public void SetupBlockCracks()
        {
            _spriteRenderer.enabled = true;
            _spriteRenderer.sprite = null;
        }

        public void UpdateBlockCracks(int lifeCount)
        {
            if (lifeCount != 0)
            {
                var newSprite = _lifeSettings.GetSpriteByLifeCount(lifeCount);
                _spriteRenderer.sprite = newSprite;
            }
            else
            {
                _spriteRenderer.enabled = false;
            }
        }
    }
}