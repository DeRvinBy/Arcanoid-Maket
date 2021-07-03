using Project.Scripts.GameSettings.GameBlockSettings;
using Project.Scripts.Utils.Extensions;
using UnityEngine;

namespace Project.Scripts.GameComponents.SpriteComponents
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
            print("setup");
            _spriteRenderer.sprite = null;
        }

        public void UpdateBlockCracks(int lifeCount)
        {
            print("update sprite");
            var newSprite = _lifeSettings.GetSpriteByLifeCount(lifeCount);
            _spriteRenderer.sprite = newSprite;
        }
    }
}