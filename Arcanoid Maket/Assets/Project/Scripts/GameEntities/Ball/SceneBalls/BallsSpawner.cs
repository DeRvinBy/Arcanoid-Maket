using Project.Scripts.EntitiesCreation.BallCreation;
using UnityEngine;

namespace Project.Scripts.GameEntities.Ball.SceneBalls
{
    public class BallsSpawner : MonoBehaviour
    {
        private BallEntity _currentBall;

        public BallEntity SpawnBallAtPosition(Vector3 spawnPosition, Transform spawnTransform)
        {
            _currentBall = BallPoolManager.Instance.GetObject(spawnPosition, spawnTransform);
            return _currentBall;
        }
        
        public void PushBallInDirection(Vector2 direction)
        {
            if (_currentBall == null) return;
            
            _currentBall.MoveBallInDirection(direction);
            _currentBall.transform.parent = null;
            _currentBall = null;
        }
        
        public void DestroyBall(BallEntity ball)
        {
            BallPoolManager.Instance.ReturnObject(ball);
        }
    }
}