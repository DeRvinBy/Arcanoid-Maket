using Project.Scripts.EntitiesCreation.BallCreation;
using UnityEngine;

namespace Project.Scripts.GameEntities.Ball.SceneBalls
{
    public class SceneBallsSpawner : MonoBehaviour
    {
        private BallController _currentBall;

        public void SpawnBallAtPosition(Vector3 spawnPosition, Transform spawnTransform)
        {
            _currentBall = BallPoolManager.Instance.GetObject(spawnPosition, spawnTransform);
        }
        
        public void PushBallInDirection(Vector2 direction)
        {
            if (_currentBall == null) return;
            
            _currentBall.SetStartDirection(direction);
            _currentBall.transform.parent = null;
            _currentBall = null;
        }
    }
}