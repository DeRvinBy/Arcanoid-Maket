using Project.Scripts.GameSettings.GameBallSettings;
using Project.Scripts.Utils.ObjectPool.Interfaces;
using UnityEngine;

namespace Project.Scripts.MVC.Ball
{
    public class BallController : MonoBehaviour, IPoolObject
    {
        [SerializeField]
        private BallView _view = null;

        private BallModel _model;
        private BallSettings _settings;

        public void Initialize(BallSettings settings)
        {
            _settings = settings;
            _model = new BallModel();
            _view.Initialize(_model);
        }

        public void SetStartDirection(Vector2 startDirection)
        {
            _view.SetMovementDirection(startDirection);
        }
        
        public void Setup()
        {
            _model.SetVelocity(_settings.StartVelocity);
            _model.SetDamage(_settings.BallDamage);
            _view.SetupView();
        }

        public void Reset()
        {
            
        }
    }
}