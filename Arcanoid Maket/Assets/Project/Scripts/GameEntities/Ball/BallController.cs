using Project.Scripts.GameSettings.GameBallSettings;
using Project.Scripts.Utils.ObjectPool.Interfaces;
using UnityEngine;

namespace Project.Scripts.GameEntities.Ball
{
    public class BallController : MonoBehaviour, IPoolObject
    {
        [SerializeField]
        private BallView _view;

        private BallModel _model;

        public void Initialize(BallSettings settings)
        {
            _model = new BallModel();
            _model.Initialize(settings);
            _view.Initialize(_model);
        }

        public void SetStartDirection(Vector2 startDirection)
        {
            _view.SetupView(startDirection);
        }
        
        public void Setup()
        {
            _model.SetupModel();
        }

        public void Reset()
        {
            _view.ResetView();
        }
    }
}