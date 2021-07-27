using BehaviorControllers.Abstract;
using BehaviorControllers.EntitiesControllers.EntitiesManagers;
using EventInterfaces.BallEvents;
using EventInterfaces.BlockEvents;
using EventInterfaces.StatesEvents;
using GameEntities.Ball;
using GameSettings.GameBallSettings;
using MyLibrary.EventSystem;
using UnityEngine;

namespace BehaviorControllers.EntitiesControllers
{
    public class BallsVelocityController : EntityController, IBallsManagerHandler, IBlockDestroyedHandler, IPrepareGameplayHandler
    {
        [SerializeField]
        private BallsManager _ballsManager;

        [SerializeField]
        private BallsVelocitySettings _velocitySettings;
        
        private float _currentBallsVelocity;
        private float _additionalVelocity;

        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(this);
        }

        public void SetAdditionalVelocity(float additionalVelocity)
        {
            _additionalVelocity = additionalVelocity;
            UpdateBallsVelocity();
        }

        private void UpdateBallsVelocity()
        {
            var velocity = _currentBallsVelocity + _additionalVelocity;
            _ballsManager.InvokeBallsAction(a => a.SetCurrentVelocity(velocity));
        }
        
        public void OnSpawnNewBall(BallEntity ball)
        {
            ball.SetCurrentVelocity(_currentBallsVelocity + _additionalVelocity);
        }
        
        public void OnBlockDestroy()
        {
            _currentBallsVelocity += _velocitySettings.AdditionalVelocityPerBlock;
            if (_currentBallsVelocity > _velocitySettings.MaxAdditionalVelocity)
            {
                _currentBallsVelocity = _velocitySettings.MaxAdditionalVelocity;
            }

            UpdateBallsVelocity();
        }
        
        public void OnPrepareGame()
        {
            _currentBallsVelocity = _velocitySettings.StartVelocity;
        }
    }
}