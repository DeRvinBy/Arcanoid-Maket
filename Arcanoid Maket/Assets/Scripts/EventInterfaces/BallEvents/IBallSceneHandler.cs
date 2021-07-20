using GameEntities.Ball;
using MyLibrary.EventSystem;
using UnityEngine;

namespace EventInterfaces.BallEvents
{
    public interface IBallSceneHandler : IGlobalSubscriber
    {
        void OnSpawnBallAtPlatform(Transform platformTransform);
        void OnDestroyBall(BallEntity ball);
    }
}