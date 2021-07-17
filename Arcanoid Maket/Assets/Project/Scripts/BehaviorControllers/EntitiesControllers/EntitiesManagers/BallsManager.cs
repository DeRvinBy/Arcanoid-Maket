using System.Collections.Generic;
using Project.Scripts.BehaviorControllers.Abstract;
using Project.Scripts.EventInterfaces.BallEvents;
using Project.Scripts.EventInterfaces.GameEvents;
using Project.Scripts.EventInterfaces.StatesEvents;
using Project.Scripts.GameComponents.Balls;
using Project.Scripts.GameEntities.Ball;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.BehaviorControllers.EntitiesControllers.EntitiesManagers
{
    public class BallsManager : EntityController, IBallSceneHandler, IEndGameplayHandler, IPrepareGameplayHandler
    {
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
            _ballOnScene = new List<BallEntity>();
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
                EventBus.RaiseEvent<IPlayerBallsEndedHandler>(a => a.OnPlayerBallsEnded());
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