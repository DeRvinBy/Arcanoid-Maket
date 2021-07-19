using GameEntities.Ball.Behaviour;
using GameSettings.GameBallSettings;
using Library.ObjectPool.Abstract;
using UnityEngine;

namespace GameEntities.Ball
{
    public class BallEntity : PoolObject
    {
        [SerializeField]
        private BallMovement _movement;

        private BallSettings _settings;
        
        public void Initialize(BallSettings settings)
        {
            _settings = settings;
        }

        public void MoveBallInDirection(Vector2 startDirection)
        {
            var velocity = startDirection * _settings.StartVelocity;
            _movement.StartBallWithVelocity(velocity);
        }

        public override void Reset()
        {
            base.Reset();
            _movement.DisableMovement();
        }
    }
}