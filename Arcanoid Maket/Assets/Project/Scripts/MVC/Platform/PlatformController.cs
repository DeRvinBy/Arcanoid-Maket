using Project.Scripts.EventInterfaces.StatesInterfaces;
using Project.Scripts.GameSettings.GamePlatformSettings;
using Project.Scripts.MVC.Abstract;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.MVC.Platform
{
    public class PlatformController : SceneEntitiesController, IMainGameStateEvent
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
        
        public void StartController()
        {
            _input.OnMousePositionUpdated += _view.UpdatePlatformPosition;
            _input.OnMouseButtonUp += _spawnBallBehaviour.PushBall;
            _model.StartModel();
            _view.StartView();
            _spawnBallBehaviour.StartBehaviour();;
        }
    }
}