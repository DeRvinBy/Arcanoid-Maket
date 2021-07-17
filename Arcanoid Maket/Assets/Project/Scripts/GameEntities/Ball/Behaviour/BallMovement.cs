using System;
using UnityEngine;

namespace Project.Scripts.GameEntities.Ball.Behaviour
{
    public class BallMovement : MonoBehaviour
    {
        private const float ThresholdVelocityChangeValue = 0.01f;
        
        [SerializeField]
        private Rigidbody2D _rigidbody;

        private float _currentVelocity;

        public void StartBallWithVelocity(Vector2 velocity)
        {
            _currentVelocity = velocity.magnitude;
            _rigidbody.velocity = velocity;
            _rigidbody.simulated = true;
        }

        public void DisableMovement()
        {
            _rigidbody.simulated = false;
        }
        
        private void Update()
        {
            if (Math.Abs(_rigidbody.velocity.magnitude - _currentVelocity) > ThresholdVelocityChangeValue)
            {
                _rigidbody.velocity = _rigidbody.velocity.normalized * _currentVelocity;
            }
        }
    }
}