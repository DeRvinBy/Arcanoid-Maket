using EventInterfaces.Input;
using GameEntities.Ball;
using Library.EventSystem;
using UnityEngine;

namespace GameComponents.Balls
{
    public class BallPlatformSpawn : IPushBallHandler
    {
        private readonly Vector2 _ballDirectionUp = Vector2.up;
        private BallEntity _currentBall;
        private Transform _parentOfPushedBall;
        
        public BallPlatformSpawn()
        {
            EventBus.Subscribe(this);
        }

        ~BallPlatformSpawn()
        {
            EventBus.Unsubscribe(this);
        }

        public void SetParentForPushingBall(Transform parent)
        {
            _parentOfPushedBall = parent;
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
            _currentBall.transform.SetParent(_parentOfPushedBall);
            _currentBall = null;
        }
    }
}