using System.Collections;
using Project.Scripts.Architecture.Abstract;
using Project.Scripts.EventInterfaces.BallEvents;
using Project.Scripts.EventInterfaces.GameEvents;
using Project.Scripts.EventInterfaces.StatesEvents;
using Project.Scripts.GameSettings.GamePlatformSettings;
using Project.Scripts.Input;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.GameEntities.Platform
{
    public class PlatformController : SceneEntitiesController, IMainGameStateStartHandler, IContinueGameHandler
    {
        [SerializeField]
        private MouseInput _input;
        
        [SerializeField]
        private PlatformSettings _settings;

        [SerializeField]
        private PlatformView _view;

        [SerializeField]
        private Transform _spawnPlatformTransform;

        private PlatformModel _model;
        
        public override void Initialize()
        {
            _model = new PlatformModel();
            _model.Initialize(_settings);
            _view.Initialize(_model);

            EventBus.Subscribe(this);
        }
        
        public void OnStartGame()
        {
            _input.OnMousePositionUpdated += _view.UpdatePlatformPosition;
            _model.StartModel();
            _view.StartView();
            SpawnBall();
        }

        public void OnContinueGame()
        {
            StartCoroutine(ResetPlatform());
        }
        
        private IEnumerator ResetPlatform()
        {
            var coroutine = _view.ResetPlatformPosition();
            yield return StartCoroutine(coroutine);
            SpawnBall();
        }

        private void SpawnBall()
        {
            EventBus.RaiseEvent<IBallSpawnHandler>(a => 
                a.OnSpawnBallAtPosition(_spawnPlatformTransform.position, _spawnPlatformTransform));
        }
    }
}