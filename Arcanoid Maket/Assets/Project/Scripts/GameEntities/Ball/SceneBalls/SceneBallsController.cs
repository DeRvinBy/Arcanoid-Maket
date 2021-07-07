using Project.Scripts.Architecture.Abstract;
using Project.Scripts.EventInterfaces.BallEvents;
using Project.Scripts.Input;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.GameEntities.Ball.SceneBalls
{
    public class SceneBallsController : SceneEntitiesController, IBallSpawnHandler
    {
        [SerializeField]
        private MouseInput _input;

        [SerializeField]
        private SceneBallsSpawner _spawner;

        private readonly Vector3 _ballDirectionOfMouseEvent = Vector3.up;
        private SceneBallsModel _model;
        
        public override void Initialize()
        {
            _model = new SceneBallsModel();
            _input.OnMouseButtonUp += () => OnPushBallInDirection(_ballDirectionOfMouseEvent);

            EventBus.Subscribe(this);
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
    }
}