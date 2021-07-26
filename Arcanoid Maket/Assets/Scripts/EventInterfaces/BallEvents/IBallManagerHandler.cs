using GameEntities.Ball;
using MyLibrary.EventSystem;

namespace EventInterfaces.BallEvents
{
    public interface IBallsManagerHandler : IGlobalSubscriber
    {
        void OnSpawnNewBall(BallEntity ball);
    }
}