using Project.Scripts.EventInterfaces.Input;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.GameEntities.Ball.SceneBalls
{
    public class BallPlatformSpawn : IPushBallHandler
    {
        private readonly Vector3 _ballDirectionUp = Vector3.up;
        private BallEntity _currentBall;
        
        public void SetBallToPlatform(BallEntity ball)
        {
            _currentBall = ball;
            
            EventBus.Subscribe(this);
        }

        public void OnPush()
        {
            if (_currentBall == null) return;
            
            _currentBall.MoveBallInDirection(_ballDirectionUp);
            _currentBall.transform.parent = null;
            _currentBall = null;
        }
    }
}