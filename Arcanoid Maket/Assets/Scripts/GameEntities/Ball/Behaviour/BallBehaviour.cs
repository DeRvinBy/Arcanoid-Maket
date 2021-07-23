﻿using System;
using System.Collections;
using GameComponents.Field;
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
            if (Math.Abs(_rigidbody.velocity.magnitude - _currentVelocity) > ThresholdVelocityChangeValue)
            {
                _rigidbody.velocity = _rigidbody.velocity.normalized * _currentVelocity;
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.IsColliderHasMonoBehaviour<FieldBorders>())
            {
                UpdateBounceDirection();
            }
        }

        private void UpdateBounceDirection()
        {
            Vector3 outDirection = _rigidbody.velocity.normalized;
            var signX = Mathf.Sign(Vector2.Dot(outDirection, Vector2.right));
            var angle = Vector2.Angle(outDirection, Vector2.right * signX);
            if (angle < _settings.BounceAngleThreshold)
            {
                var signY =  Mathf.Sign(Vector2.Dot(outDirection, Vector2.up));
                var targetAngle = _settings.BounceAngleChange * signX * signY;
                var targetQuaternion = Quaternion.Euler(0f, 0f, targetAngle);
                _rigidbody.velocity = targetQuaternion * outDirection * _currentVelocity;
            }
        }
    }
}