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
        private BallMovement _movement;

        [SerializeField]
        private GeneralCollider2D _collider;
        
        private BallSettings _settings;
        private float _currentVelocity;
        private int _currentDamage;

        public int BallDamage => _currentDamage;

        public void Initialize(BallSettings settings)
        {
            _settings = settings;
        }

        public void SetAdditionalVelocity(float additionalVelocity)
        {
            _currentVelocity = _settings.BaseVelocity + additionalVelocity;
            _movement.SetVelocity(_currentVelocity);
        }
        
        public void MoveBallInDirection(Vector2 startDirection)
        {
            var velocity = startDirection * _currentVelocity;
            _movement.StartBallWithVelocity(velocity);
        }

        public override void OnSetup()
        {
            base.OnSetup();
            _currentDamage = _settings.BallDamage;
            _currentVelocity = _settings.BaseVelocity;
            _collider.RegisterCollider(this);
        }

        public override void OnReset()
        {
            base.OnReset();
            _movement.DisableMovement();
            _collider.UnregisterCollider(this);
        }
    }
}