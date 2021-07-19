using Scripts.BehaviorControllers.Abstract;
using Scripts.EventInterfaces.GameEvents;
using Scripts.EventInterfaces.StatesEvents;
using Scripts.GameSettings.LifeSettings;
using Scripts.UI.Header.LifeUI;
using Scripts.Utils.EventSystem;
using UnityEngine;

namespace Scripts.BehaviorControllers.EntitiesControllers
{
    public class LifeController : EntityController, IStartGameplayHandler, IPlayerBallsHandler
    {
        [SerializeField]
        private LifeSettings _settings;

        [SerializeField]
        private LifeUI _lifeUI;

        private int _lifeCount;

        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(this);
        }

        public override void Initialize()
        {
            _lifeUI.CreateLifeContainers(_settings);
        }

        public void OnStartGame()
        {
            _lifeCount = _settings.StartLifeCount;
            _lifeUI.UpdateLifeCount(_lifeCount);
        }
        
        public void OnPlayerBallLose()
        {
            _lifeCount--;
            _lifeUI.UpdateLifeCount(_lifeCount);
            
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