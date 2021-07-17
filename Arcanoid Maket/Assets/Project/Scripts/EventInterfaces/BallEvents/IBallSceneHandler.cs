using Project.Scripts.GameEntities.Ball;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.EventInterfaces.BallEvents
{
    public interface IBallSceneHandler : IGlobalSubscriber
    {
        void OnSpawnBallAtPlatform(Transform platformTransform);
        void OnDestroyBall(BallEntity ball);
    }
}