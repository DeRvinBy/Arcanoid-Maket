using GameEntities.Ball.Behaviour;
using GameSettings.GameBallSettings;
using MyLibrary.CollisionStorage.Colliders2D;
using MyLibrary.ObjectPool.Abstract;
using UnityEngine;

namespace GameEntities.Ball
{
    public class BallEntity : PoolObject
    {
        [SerializeField]
        private BallBehaviour _behaviour;

        [SerializeField]
        private SpriteRenderer _ballSprite;
        
        [SerializeField]
        private GeneralCollider2D _collider;
        
        private BallSettings _settings;
        private float _currentVelocity;
        private int _currentDamage;

        public int BallDamage => _currentDamage;

        public void Initialize(BallSettings settings)
        {
            _settings = settings;
            _behaviour.Initialize(settings);
        }

        public void SetSprite(Sprite newSprite)
        {
            _ballSprite.sprite = newSprite;
        }

        public void ResetDefaultSprite()
        {
            _ballSprite.sprite = _settings.BallSprite;
        }

        public void SetAdditionalVelocity(float additionalVelocity)
        {
            _currentVelocity = _settings.BaseVelocity + additionalVelocity;
            _behaviour.SetVelocity(_currentVelocity);
        }
        
        public void MoveBallInDirection(Vector2 startDirection)
        {
            var velocity = startDirection * _currentVelocity;
            _behaviour.StartBallWithVelocity(velocity);
        }

        public override void OnSetup()
        {
            base.OnSetup();
            _currentDamage = _settings.BallDamage;
            _currentVelocity = _settings.BaseVelocity;
            _ballSprite.sprite = _settings.BallSprite;
            _collider.RegisterCollider(this);
        }

        public override void OnReset()
        {
            base.OnReset();
            _behaviour.DisableMovement();
            _collider.UnregisterCollider(this);
        }
    }
}