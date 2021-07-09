using Project.Scripts.BehaviorControllers.Abstract;
using Project.Scripts.EventInterfaces.GameEvents;
using Project.Scripts.EventInterfaces.StatesEvents;
using Project.Scripts.GameSettings.PlayerSettings;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.GameEntities.Player
{
    public class LifeController : EntityController, IMainGameStateStartHandler, IPlayerBallsEndedHandler
    {
        [SerializeField]
        private LifeSettings _settings;

        [SerializeField]
        private LifeUI _lifeUI;

        private LifeModel _model;
        
        public override void Initialize()
        {
            _model = new LifeModel();
            _lifeUI.Initialize(_settings);
            
            EventBus.Subscribe(this);
        }

        public void OnStartGame()
        {
            _model.SetLifeCount(_settings.StartLifeCount);
            _lifeUI.SetLifeCountInUI(_model.LifeCount);
        }
        
        public void OnPlayerBallsEnded()
        {
            _model.ReduceLifeByOne();
            _lifeUI.SetLifeCountInUI(_model.LifeCount);
            
            if (_model.LifeCount <= 0)
            {
                EventBus.RaiseEvent<IEndGameHandler>(a => a.OnLoseGame());
            }
            else
            {
                EventBus.RaiseEvent<IContinueGameHandler>(a => a.OnContinueGame());
            }
        }
    }
}