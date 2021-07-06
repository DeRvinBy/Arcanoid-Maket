using System.Collections;
using Project.Scripts.Architecture.Abstract;
using Project.Scripts.EventInterfaces.GameEvents;
using Project.Scripts.EventInterfaces.StatesEvents;
using Project.Scripts.GameSettings.GamePlatformSettings;
using Project.Scripts.Input;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.GameEntities.Platform
{
    public class PlatformController : SceneEntitiesController, IMainGameStateStartHandler, IContinueGameEvent
    {
        [SerializeField]
        private MouseInput _input;
        
        [SerializeField]
        private PlatformSettings _settings;

        [SerializeField]
        private PlatformView _view;

        [SerializeField]
        private PlatformSpawnBallBehaviour _spawnBallBehaviour;

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
            _input.OnMouseButtonUp += _spawnBallBehaviour.PushBall;
            _model.StartModel();
            _view.StartView();
            _spawnBallBehaviour.StartBehaviour();
        }

        public void OnContinueGame()
        {
            StartCoroutine(WaitToSpawnBall());
        }

        private IEnumerator WaitToSpawnBall()
        {
            var coroutine = StartCoroutine(_view.ResetPlatformPosition());
            yield return coroutine;
            _spawnBallBehaviour.StartBehaviour();
        }
    }
}