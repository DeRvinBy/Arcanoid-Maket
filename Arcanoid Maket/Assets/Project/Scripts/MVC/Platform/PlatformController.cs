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
        private PlatformSettings _settings;
        
        [SerializeField]
        private UserInput _input;
        
        [SerializeField]
        private PlatformView _view = null;

        private PlatformModel _model;
        
        public override void Initialize()
        {
            _model = new PlatformModel();
            _view.Initialize(_model);

            EventBus.Subscribe(this);
        }
        
        public void StartController()
        {
            _model.SetSpeed(_settings.Speed);
            _model.SetSize(_settings.StartSize);
            _input.OnMousePositionUpdated += _view.UpdatePlatformPosition;
            _view.StartView();
        }
    }
}