using UnityEngine;

namespace Project.Scripts.GameEntities.Ball.SceneBalls
{
    public class BallPlatformSpawn
    {
        private readonly Vector3 _ballDirectionUp = Vector3.up;
        private BallEntity _currentBall;
        
        public void SetBallToPlatform(BallEntity ball)
        {
            _currentBall = ball;
        }

        public void PushBallFromPlatform()
        {
            if (_currentBall == null) return;
            
            _currentBall.MoveBallInDirection(_ballDirectionUp);
            _currentBall.transform.parent = null;
            _currentBall = null;
        }
    }
}