using System;
using System.Collections.Generic;
using BehaviorControllers.Abstract;
using EventInterfaces.BallEvents;
using EventInterfaces.BonusEvents;
using EventInterfaces.GameEvents;
using EventInterfaces.StatesEvents;
using GameComponents.Balls;
using GameEntities.Ball;
using MyLibrary.EventSystem;
using UnityEngine;

namespace BehaviorControllers.EntitiesControllers.EntitiesManagers
{
    public class BallsManager : EntityController, IBallSceneHandler, IEndGameplayHandler, IPrepareGameplayHandler
    {
        [SerializeField]
        private Transform _ballParent;

        private BallsSpawner _spawner;
        private BallPlatformSpawn _platformSpawn;
        private List<BallEntity> _ballOnScene;

        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(this);
        }

        public override void Initialize()
        {
            _spawner = new BallsSpawner();
            _platformSpawn = new BallPlatformSpawn();
            _platformSpawn.SetParentForPushingBall(_ballParent);
            _ballOnScene = new List<BallEntity>();
        }

        public void SpawnBallInDirection(Vector2 position, Vector2 direction)
        {
            var ball = _spawner.SpawnBall(position, _ballParent);
            ball.MoveBallInDirection(direction);
            EventBus.RaiseEvent<IBallVelocityBonusHandler>(a => a.UpdateVelocityForNewBall(ball));
            _ballOnScene.Add(ball);
        }

        public void OnSpawnBallAtPlatform(Transform platformTransform)
        {
            var ball = _spawner.SpawnBall(platformTransform.position);
            _platformSpawn.SetBallToPlatform(ball, platformTransform);
            _ballOnScene.Add(ball);
        }

        public void OnDestroyBall(BallEntity ball)
        {
            _spawner.DestroyBall(ball);
            _ballOnScene.Remove(ball);
            
            if (_ballOnScene.Count <= 0)
            {
                EventBus.RaiseEvent<IPlayerBallsHandler>(a => a.OnPlayerBallLose());
            }
        }

        public void InvokeBallsAction(Action<BallEntity> action)
        {
            foreach (var ball in _ballOnScene)
            {
                action.Invoke(ball);
            }
        }
        
        public void OnPrepareGame()
        {
            DestroyAllBalls();
        }
        
        public void OnEndGame()
        {
            DestroyAllBalls();
        }
        
        private void DestroyAllBalls()
        {
            foreach (var ball in _ballOnScene)
            {
                _spawner.DestroyBall(ball);
            }
            _ballOnScene.Clear();
        }
    }
}