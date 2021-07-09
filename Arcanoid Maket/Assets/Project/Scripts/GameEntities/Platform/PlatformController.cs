using System.Collections;
using Project.Scripts.BehaviorControllers.Abstract;
using Project.Scripts.EventInterfaces.BallEvents;
using Project.Scripts.EventInterfaces.GameEvents;
using Project.Scripts.EventInterfaces.StatesEvents;
using Project.Scripts.GameSettings.GamePlatformSettings;
using Project.Scripts.Input;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;
using IStartGameplayHandler = Project.Scripts.EventInterfaces.StatesEvents.IStartGameplayHandler;

namespace Project.Scripts.GameEntities.Platform
{
    public class PlatformController : EntityController, IStartGameplayHandler, IEndGameplayHandler, IContinueGameHandler
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
        
        public void OnEndGame()
        {
            _view.DisablePlatform();
        }
        
        private IEnumerator ResetPlatform()
        {
            var routine = _view.ResetPlatformPosition();
            yield return StartCoroutine(routine);
            SpawnBall();
        }

        private void SpawnBall()
        {
            EventBus.RaiseEvent<IBallSceneHandler>(a => 
                a.OnSpawnBallAtPosition(_spawnPlatformTransform.position, _spawnPlatformTransform));
        }
    }
}