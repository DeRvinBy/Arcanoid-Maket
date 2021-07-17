using Project.Scripts.BehaviorControllers.Abstract;
using Project.Scripts.EventInterfaces.GameEvents;
using Project.Scripts.GameSettings.PlayerSettings;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;
using IStartGameplayHandler = Project.Scripts.EventInterfaces.StatesEvents.IStartGameplayHandler;

namespace Project.Scripts.GameEntities.PlayerLife
{
    public class LifeController : EntityController, IStartGameplayHandler, IPlayerBallsEndedHandler
    {
        [SerializeField]
        private LifeSettings _settings;

        [SerializeField]
        private LifeUI _lifeUI;

        private int _lifeCount;
        
        public override void Initialize()
        {
            _lifeUI.CreateLifeContainers(_settings);
            EventBus.Subscribe(this);
        }

        public void OnStartGame()
        {
            _lifeCount = _settings.StartLifeCount;
            _lifeUI.SetLifeCountInUI(_lifeCount);
        }
        
        public void OnPlayerBallsEnded()
        {
            _lifeCount--;
            _lifeUI.SetLifeCountInUI(_lifeCount);
            
            if (_lifeCount <= 0)
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