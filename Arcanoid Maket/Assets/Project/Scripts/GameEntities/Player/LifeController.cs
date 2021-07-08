using Project.Scripts.Architecture.Abstract;
using Project.Scripts.EventInterfaces.GameEvents;
using Project.Scripts.EventInterfaces.GameFieldEvents;
using Project.Scripts.GameSettings.PlayerSettings;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.GameEntities.Player
{
    public class LifeController : SceneEntitiesController, IPlayerBallsEndedHandler
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

        public void OnPlayerBallsEnded()
        {
            _model.ReduceLifeByOne();
            _lifeUI.SetLifeCountInUI(_model.LifeCount);
            
            if (_model.LifeCount <= EndGameLifeCount)
            {
                EventBus.RaiseEvent<ILoseGameHandler>(a => a.OnLoseGame());
            }
            else
            {
                EventBus.RaiseEvent<IContinueGameHandler>(a => a.OnContinueGame());
            }
        }
    }
}