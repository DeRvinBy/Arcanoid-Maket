using Project.Scripts.GameSettings.PlayerSettings;
using Project.Scripts.MVC.Abstract;
using Project.Scripts.MVC.GameField.EventInterfaces;
using Project.Scripts.MVC.Player.EventInterfaces;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.MVC.Player
{
    public class LifeController : SceneEntitiesController, IBallOutBorderEvent
    {
        private const int EndGameLifeCount = 0;
        
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

            EventBus.Subscribe(this);
        }

        public void OnBallOut()
        {
            _model.ReduceLifeByOne();
            _lifeUI.SetLifeCountInUI(_model.LifeCount);
            
            if (_model.LifeCount <= EndGameLifeCount)
            {
                EventBus.RaiseEvent<IEndGameEvent>(a => a.OnEndGame());
            }
            else
            {
                EventBus.RaiseEvent<IContinueGameEvent>(a => a.ContinueGame());
            }
        }
    }
}