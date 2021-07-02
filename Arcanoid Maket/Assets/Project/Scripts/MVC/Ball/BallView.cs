using UnityEngine;

namespace Project.Scripts.MVC.Ball
{
    public class BallView : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D _rigidbody;

        private BallModel _model;
        private Vector2 _movementDirection;
        
        public void Initialize(BallModel model)
        {
            _model = model;
        }

        public void SetMovementDirection(Vector2 movementDirection)
        {
            _movementDirection = movementDirection;
        }

        public void SetupView()
        {
            _rigidbody.velocity = _movementDirection * _model.Velocity;
            _rigidbody.simulated = true;
        }

        public void ResetView()
        {
            _rigidbody.simulated = false;
        }
    }
}