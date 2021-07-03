using System.Collections;
using Project.Scripts.GameSettings.GamePlatformSettings;
using Project.Scripts.MVC.Ball;
using Project.Scripts.MVC.Ball.Creation;
using UnityEngine;

namespace Project.Scripts.MVC.Platform
{
    public class PlatformView : MonoBehaviour
    {
        [SerializeField]
        private Camera _sceneCamera;
        
        [SerializeField]
        private Rigidbody2D _rigidbody;
        
        [SerializeField]
        private PlatformSpawnBallSettings _spawnBallSettings;
        
        [SerializeField]
        private Transform _spawnBallTransform = null;

        private readonly Vector3 _spawnDirectionUp = Vector3.up;
        private PlatformModel _model;
        private Transform _transform;

        public void Initialize(PlatformModel model)
        {
            _model = model;
            _transform = transform;
        }

        public void UpdatePlatformPosition(Vector2 mousePosition)
        {
            var targetPosition = _sceneCamera.ScreenToWorldPoint(mousePosition);
            var currentPosition = _transform.position;
            targetPosition.y = currentPosition.y;
            var movement = Vector3.Lerp( currentPosition, targetPosition, _model.Speed * Time.deltaTime);
            _rigidbody.MovePosition(movement);
        }
        
        public void StartView()
        {
            SetupScale();
            StartCoroutine(SpawnBallWithDelay());
        }

        private void SetupScale()
        {
            var scale = _transform.localScale;
            scale.x *= _model.Size;
            _transform.localScale = scale;
        }

        private IEnumerator SpawnBallWithDelay()
        {
            var ball = CreateSpawnBallOnPlatform();
            yield return new WaitForSeconds(_spawnBallSettings.DelayToSpawnBall);
            StartBallInDirection(ball);
        }

        private BallController CreateSpawnBallOnPlatform()
        {
            var ball = BallPoolManager.GetObject(_spawnBallTransform.position);
            ball.transform.parent = _spawnBallTransform;
            return ball;
        }

        private void StartBallInDirection(BallController ball)
        {
            var angle = _spawnBallSettings.RandomAngle;
            var direction = Quaternion.Euler(0, 0, angle) * _spawnDirectionUp;
            ball.SetStartDirection(direction);
            ball.transform.parent = null;
        }
    }
}