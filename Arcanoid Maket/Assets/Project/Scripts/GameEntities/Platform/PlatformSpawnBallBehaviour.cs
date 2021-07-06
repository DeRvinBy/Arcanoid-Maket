using Project.Scripts.EntitiesCreation.BallCreation;
using Project.Scripts.GameEntities.Ball;
using UnityEngine;

namespace Project.Scripts.GameEntities.Platform
{
    public class PlatformSpawnBallBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Transform _spawnBallTransform = null;
        
        private readonly Vector3 _spawnDirectionUp = Vector3.up;
        private BallController _currentBall;
        private bool _isBallPushed;
        
        public void StartBehaviour()
        {
            CreateSpawnBallOnPlatform();
            _isBallPushed = false;
        }
        
        private void CreateSpawnBallOnPlatform()
        {
            _currentBall = BallPoolManager.GetObject(_spawnBallTransform.position, _spawnBallTransform);
        }

        public void PushBall()
        {
            if (_isBallPushed) return;
            
            _currentBall.SetStartDirection(_spawnDirectionUp);
            _currentBall.transform.parent = null;
            _currentBall = null;
            _isBallPushed = true;
        }
    }
}