using Project.Scripts.EntitiesCreation.BallCreation;
using Project.Scripts.Utils.ObjectPool;
using UnityEngine;

namespace Project.Scripts.GameEntities.Ball.SceneBalls
{
    public class BallsSpawner
    {
        public BallEntity SpawnBallAtPosition(Vector3 spawnPosition, Transform spawnTransform)
        {
            return PoolsManager.Instance.GetObject<BallEntity>(spawnPosition, spawnTransform);
        }

        public void DestroyBall(BallEntity ball)
        {
            PoolsManager.Instance.ReturnObject(ball);
        }
    }
}