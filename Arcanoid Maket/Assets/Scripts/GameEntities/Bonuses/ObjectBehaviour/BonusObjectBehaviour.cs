using UnityEngine;

namespace GameEntities.Bonuses.ObjectBehaviour
{
    public class BonusObjectBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D _rigidbody;
        
        [SerializeField]
        private SpriteRenderer _bonusSprite;

        public void Initialize(float gravityScale)
        {
            _rigidbody.gravityScale = gravityScale;
        }
        
        public void SetupBehaviour(Sprite bonusSprite)
        {
            _bonusSprite.sprite = bonusSprite;
        }
    }
}