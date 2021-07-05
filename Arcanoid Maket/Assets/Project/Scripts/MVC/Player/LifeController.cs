using Project.Scripts.GameSettings.PlayerSettings;
using Project.Scripts.MVC.Abstract;
using UnityEngine;

namespace Project.Scripts.MVC.Player
{
    public class LifeController : SceneEntitiesController
    {
        [SerializeField]
        private LifeSettings _settings;

        [SerializeField]
        private LifeUI _lifeUI;

        private LifeModel _model;
        
        public override void Initialize()
        {
            _model = new LifeModel();
            _model.Initialize(_settings);
            _lifeUI.Initialize(_settings);
            _model.OnLifeCountChanged += _lifeUI.SetLifeCountInUI;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _model.ReduceLifeByOne();
            }
        }
    }
}