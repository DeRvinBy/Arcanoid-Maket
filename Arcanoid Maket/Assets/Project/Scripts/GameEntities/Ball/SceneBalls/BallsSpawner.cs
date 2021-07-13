using Project.Scripts.EntitiesCreation.BallCreation;
using UnityEngine;

namespace Project.Scripts.GameEntities.Ball.SceneBalls
{
    public class BallsSpawner
    {
        public BallEntity SpawnBallAtPosition(Vector3 spawnPosition, Transform spawnTransform)
        {
            return BallPoolManager.Instance.GetObject(spawnPosition, spawnTransform);
        }

        public void DestroyBall(BallEntity ball)
        {
            BallPoolManager.Instance.ReturnObject(ball);
        }
    }
}