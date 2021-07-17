using Project.Scripts.EventInterfaces.Input;
using Project.Scripts.GameEntities.Ball;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.GameComponents.Balls
{
    public class BallPlatformSpawn : IPushBallHandler
    {
        private readonly Vector2 _ballDirectionUp = Vector2.up;
        private BallEntity _currentBall;

        public BallPlatformSpawn()
        {
            EventBus.Subscribe(this);
        }

        ~BallPlatformSpawn()
        {
            EventBus.Unsubscribe(this);
        }
        
        public void SetBallToPlatform(BallEntity ball, Transform platformTransform)
        {
            ball.transform.SetParent(platformTransform);
            _currentBall = ball;
        }

        public void OnPush()
        {
            if (_currentBall == null) return;
            
            _currentBall.MoveBallInDirection(_ballDirectionUp);
            _currentBall.transform.SetParent(null);
            _currentBall = null;
        }
    }
}