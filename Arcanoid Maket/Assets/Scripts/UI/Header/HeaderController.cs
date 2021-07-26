using System;
using BehaviorControllers.Abstract;
using EventInterfaces.PacksEvents;
using EventInterfaces.StatesEvents;
using GamePacks;
using GamePacks.Data.Packs;
using MyLibrary.EventSystem;
using MyLibrary.UI.Button;
using UI.Header.PackUI;
using UnityEngine;

namespace UI.Header
{
    public class HeaderController : EntityController, IPrepareGameplayHandler
    {
        [SerializeField]
        private HeaderPackUI _headerPackUI;
        
        [SerializeField]
        private EventButton _pauseButton;

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
            _pauseButton.OnButtonPressed += OnPauseButtonPressed;
        }
        
        private void OnPauseButtonPressed()
        {
            EventBus.RaiseEvent<IPauseGameHandler>(a => a.OnPause());
        }

        public void OnPrepareGame()
        {
            var currentPack = PacksManager.Instance.GetCurrentPack();
            _headerPackUI.SetPackImage(currentPack.GamePack.Icon);
            _headerPackUI.SetLevelText(currentPack.CurrentLevel.ToString());
        }
    }
}