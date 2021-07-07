using Project.Scripts.GameEntities.Ball;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.EventInterfaces.BallEvents
{
    public interface IBallSceneHandler : IGlobalSubscriber
    {
        void OnSpawnBallAtPosition(Vector3 spawnPosition, Transform spawnTransform);
        void OnPushBallInDirection(Vector2 direction);
        void OnBallDestroyed(BallController ball);
    }
}