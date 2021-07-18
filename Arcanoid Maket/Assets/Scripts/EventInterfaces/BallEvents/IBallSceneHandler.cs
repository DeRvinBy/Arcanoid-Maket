using Scripts.GameEntities.Ball;
using Scripts.Utils.EventSystem;
using UnityEngine;

namespace Scripts.EventInterfaces.BallEvents
{
    public interface IBallSceneHandler : IGlobalSubscriber
    {
        void OnSpawnBallAtPlatform(Transform platformTransform);
        void OnDestroyBall(BallEntity ball);
    }
}