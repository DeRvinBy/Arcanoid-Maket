using System.Collections.Generic;
using Project.Scripts.BehaviorControllers.Abstract;
using Project.Scripts.EventInterfaces.BallEvents;
using Project.Scripts.EventInterfaces.GameEvents;
using Project.Scripts.EventInterfaces.StatesEvents;
using Project.Scripts.Input;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.GameEntities.Ball.SceneBalls
{
    public class BallsController : EntityController, IBallSceneHandler, IEndGameplayHandler
    {
        [SerializeField]
        private MouseInput _input;

        [SerializeField]
        private BallsSpawner _spawner;

        private List<BallEntity> _ballOnScene;
        
        private readonly Vector3 _ballDirectionOfMouseEvent = Vector3.up;

        public override void Initialize()
        {
            _ballOnScene = new List<BallEntity>();
            _input.OnMouseButtonUp += () => OnPushBallInDirection(_ballDirectionOfMouseEvent);

            EventBus.Subscribe(this);
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

        public void OnSpawnBallAtPosition(Vector3 spawnPosition, Transform spawnTransform)
        {
            var ball = _spawner.SpawnBallAtPosition(spawnPosition, spawnTransform);
            _ballOnScene.Add(ball);
        }

        public void OnPushBallInDirection(Vector2 direction)
        {
            _spawner.PushBallInDirection(direction);
        }

        public void OnBallDestroyed(BallEntity ball)
        {
            _spawner.DestroyBall(ball);
            _ballOnScene.Remove(ball);
            
            if (_ballOnScene.Count <= 0)
            {
                EventBus.RaiseEvent<IPlayerBallsEndedHandler>(a => a.OnPlayerBallsEnded());
            }
        }
    }
}