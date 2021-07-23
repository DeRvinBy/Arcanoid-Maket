using System.Collections;
using BehaviorControllers.EntitiesControllers.EntitiesManagers;
using EventInterfaces.BallEvents;
using EventInterfaces.BonusEvents;
using EventInterfaces.GameEvents;
using GameComponents.Bonus.Abstract;
using GameEntities.Ball;
using GameEntities.Blocks;
using GameSettings.GameBonusSettings.BonusesSettings;
using MyLibrary.EventSystem;
using UnityEngine;

namespace GameComponents.Bonus.BonusesManagers
{
    public class RageBallBonusManager : AbstractBonusManager, IRageBallBonusHandler, IBallsManagerHandler, IContinueGameHandler
    {
        [SerializeField]
        private BallsManager _ballsManager;

        [SerializeField]
        private BlocksManager _blocksManager;

        [SerializeField]
        private RageBallBonusSettings _settings;

        private bool _isEffectActive;
        private float _effectTime;
        
        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void OnDisable()
        {
            EventBus.Subscribe(this);
        }

        public void ActivateRageBonus()
        {
            _effectTime += _settings.EffectTime;
            if (!_isEffectActive)
            {
                StartCoroutine(StartRageEffect());
            }
        }

        private IEnumerator StartRageEffect()
        {
            StartEffect();
            var currentTime = 0f;
            while (currentTime < _effectTime)
            {
                currentTime += Time.deltaTime;
                yield return null;
            }
            EndEffect();
        }

        private void StartEffect()
        {
            _isEffectActive = true;
            _ballsManager.InvokeBallsAction(a => a.SetSprite(_settings.RageBallSprite));
            _blocksManager.InvokeBlocksAction<DestructibleBlock>(a => a.EnableBlockTrigger());
            _blocksManager.InvokeBlocksAction<BonusBlock>(a => a.EnableBlockTrigger());
        }
        
        private void EndEffect()
        {
            _isEffectActive = false;
            _effectTime = 0f;
            _ballsManager.InvokeBallsAction(a => a.ResetDefaultSprite());
            _blocksManager.InvokeBlocksAction<DestructibleBlock>(a => a.DisableBlockTrigger());
            _blocksManager.InvokeBlocksAction<BonusBlock>(a => a.DisableBlockTrigger());
        }
        
        public void OnSpawnNewBall(BallEntity ball)
        {
            if (_isEffectActive)
            {
                ball.SetSprite(_settings.RageBallSprite);
            }
        }
        
        public override void OnPrepareGame()
        {
            ResetManager();
        }
        
        public void OnContinueGame()
        {
            ResetManager();
        }

        private void ResetManager()
        {
            if (_isEffectActive)
            {
                StopAllCoroutines();
                EndEffect();
            }
        }
    }
}