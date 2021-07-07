using Project.Scripts.Architecture.Abstract;
using Project.Scripts.EventInterfaces.BallEvents;
using Project.Scripts.EventInterfaces.GameEvents;
using Project.Scripts.Input;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.GameEntities.Ball.SceneBalls
{
    public class SceneBallsController : SceneEntitiesController, IBallSceneHandler
    {
        private const int LoseBallCount = 0;
        
        [SerializeField]
        private MouseInput _input;

        [SerializeField]
        private SceneBallsSpawner _spawner;

        private readonly Vector3 _ballDirectionOfMouseEvent = Vector3.up;
        private SceneBallsModel _model;
        
        public override void Initialize()
        {
            _model = new SceneBallsModel();
            _model.OnBallCountReduced += BallCountCheck;
            _input.OnMouseButtonUp += () => OnPushBallInDirection(_ballDirectionOfMouseEvent);

            EventBus.Subscribe(this);
        }

        private void BallCountCheck(int ballCount)
        {
            if (ballCount <= LoseBallCount)
            {
                EventBus.RaiseEvent<IPlayerBallsEndedHandler>(a => a.OnPlayerBallsEnded());
            }
        }
        
        public void OnSpawnBallAtPosition(Vector3 spawnPosition, Transform spawnTransform)
        {
            _spawner.SpawnBallAtPosition(spawnPosition, spawnTransform);
            _model.IncreaseBallCount();
        }

        public void OnPushBallInDirection(Vector2 direction)
        {
            _spawner.PushBallInDirection(direction);
        }

        public void OnBallDestroyed(BallController ball)
        {
            _spawner.DestroyBall(ball);
            _model.ReduceBallCount();
        }
    }
}