using BehaviorControllers.EntitiesControllers;
using GameSettings.GameBallSettings;
using MyLibrary.CollisionStorage.Extensions;
using UnityEngine;

namespace GameEntities.Ball.Behaviour
{
    public class BallBehaviour : MonoBehaviour
    {
        private const float ThresholdVelocityChangeValue = 0.01f;
        
        [SerializeField]
        private Rigidbody2D _rigidbody;

        private BallSettings _settings;
        private float _currentVelocity;

        public void Initialize(BallSettings settings)
        {
            _settings = settings;
        }
        
        public void StartBallWithVelocity(Vector2 velocity)
        {
            _currentVelocity = velocity.magnitude;
            _rigidbody.velocity = velocity;
            _rigidbody.simulated = true;
        }

        public void SetVelocity(float velocity)
        {
            _currentVelocity = velocity;
        }

        public void DisableMovement()
        {
            _rigidbody.simulated = false;
        }
        
        private void Update()
        {
            if (Mathf.Abs(_rigidbody.velocity.magnitude - _currentVelocity) > ThresholdVelocityChangeValue)
            {
                _rigidbody.velocity = _rigidbody.velocity.normalized * _currentVelocity;
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.IsColliderHasMonoBehaviour<PlatformController>())
            {
                UpdateDirectionByPlatform();
            }
            else
            {
                UpdateBounceDirection(_settings.VerticalSettings, Vector2.right, Vector2.up);
                var bounceDirection = transform.position.x < 0f ? Vector2.up : Vector2.right; 
                UpdateBounceDirection(_settings.HorizontalSettings, Vector2.up, bounceDirection);
            }
        }

        private void UpdateBounceDirection(BallThresholdAngleSettings settings, Vector2 collisionPerpendicular, Vector2 bounceDirectionPerpendicular)
        {
            Vector3 outDirection = _rigidbody.velocity.normalized;
            var signX = Mathf.Sign(Vector2.Dot(outDirection, collisionPerpendicular));
            var angle = Vector2.Angle(outDirection, collisionPerpendicular * signX);
            if (angle < settings.BounceAngleThreshold)
            {
                var signY =  Mathf.Sign(Vector2.Dot(outDirection, bounceDirectionPerpendicular));
                var targetAngle = settings.BounceAngleChange * signX * signY;
                var targetQuaternion = Quaternion.Euler(0f, 0f, targetAngle);
                _rigidbody.velocity = targetQuaternion * outDirection * _currentVelocity;
            }
        }
        
        private void UpdateDirectionByPlatform()
        {
            Vector3 outDirection = _rigidbody.velocity.normalized;
            _rigidbody.velocity = outDirection * _currentVelocity;
        }
    }
}