using System.Collections;
using Project.Scripts.GameSettings.GamePlatformSettings;
using Project.Scripts.GameStates.States.EventInterfaces;
using Project.Scripts.MVC.Abstract;
using Project.Scripts.MVC.Player.EventInterfaces;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.MVC.Platform
{
    public class PlatformController : SceneEntitiesController, IMainGameStateEvent, IContinueGameEvent
    {
        [SerializeField]
        private UserInput _input;
        
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
        
        public void StartGame()
        {
            _input.OnMousePositionUpdated += _view.UpdatePlatformPosition;
            _input.OnMouseButtonUp += _spawnBallBehaviour.PushBall;
            _model.StartModel();
            _view.StartView();
            _spawnBallBehaviour.StartBehaviour();
        }

        public void ContinueGame()
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