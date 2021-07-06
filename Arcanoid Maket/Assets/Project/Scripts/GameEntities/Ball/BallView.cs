using System;
using UnityEngine;

namespace Project.Scripts.GameEntities.Ball
{
    public class BallView : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D _rigidbody;

        private BallModel _model;

        public void Initialize(BallModel model)
        {
            _model = model;
        }

        private void Update()
        {
            if (Math.Abs(_rigidbody.velocity.magnitude - _model.Velocity) > 0.01f)
            {
                _rigidbody.velocity = _rigidbody.velocity.normalized * _model.Velocity;
            }
        }

        public void SetupView(Vector2 movementDirection)
        {
            _rigidbody.velocity = movementDirection * _model.Velocity;
            _rigidbody.simulated = true;
        }

        public void ResetView()
        {
            _rigidbody.simulated = false;
        }
    }
}