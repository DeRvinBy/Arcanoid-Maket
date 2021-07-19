using GameEntities.Ball;
using Scripts.Utils.ObjectPool;
using UnityEngine;

namespace GameComponents.Balls
{
    public class BallsSpawner
    {
        public BallEntity SpawnBall(Vector3 spawnPosition)
        {
            return PoolsManager.Instance.GetObject<BallEntity>(spawnPosition);
        }

        public void DestroyBall(BallEntity ball)
        {
            PoolsManager.Instance.ReturnObject(ball);
        }
    }
}