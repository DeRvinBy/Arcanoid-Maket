using System.Collections.Generic;
using Project.Scripts.EntitiesCreation.BallCreation;
using UnityEngine;

namespace Project.Scripts.GameEntities.Ball.SceneBalls
{
    public class SceneBallsSpawner : MonoBehaviour
    {
        private List<BallController> _balls;
        private BallController _currentBall;

        public void SpawnBallAtPosition(Vector3 spawnPosition, Transform spawnTransform)
        {
            _balls = new List<BallController>();
            _currentBall = BallPoolManager.Instance.GetObject(spawnPosition, spawnTransform);
            _balls.Add(_currentBall);
        }
        
        public void PushBallInDirection(Vector2 direction)
        {
            if (_currentBall == null) return;
            
            _currentBall.SetStartDirection(direction);
            _currentBall.transform.parent = null;
            _currentBall = null;
        }
        
        public void DestroyBall(BallController ball)
        {
            BallPoolManager.Instance.ReturnObject(ball);
            _balls.Remove(ball);
        }

        public void DestroyAllBalls()
        {
            foreach (var ball in _balls)
            {
                BallPoolManager.Instance.ReturnObject(ball);
            }
            _balls.Clear();
        }
    }
}