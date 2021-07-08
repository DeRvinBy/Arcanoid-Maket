using Project.Scripts.GameSettings.GameBallSettings;
using Project.Scripts.Utils.ObjectPool.Interfaces;
using UnityEngine;

namespace Project.Scripts.GameEntities.Ball
{
    public class BallEntity : MonoBehaviour, IPoolObject
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
        
        public void Setup() { }

        public void Reset()
        {
            _movement.DisableMovement();
        }
    }
}