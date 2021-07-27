using System;
using BehaviorControllers.Abstract;
using EventInterfaces.PacksEvents;
using EventInterfaces.StatesEvents;
using GameComponents.Field;
using GamePacks;
using GamePacks.Data.Packs;
using GameSettings.GameFieldSettings;
using MyLibrary.EventSystem;
using MyLibrary.UI.Button;
using UI.Header.PackUI;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Header
{
    public class HeaderController : EntityController, IPrepareGameplayHandler
    {
        [SerializeField]
        private HeaderPackUI _headerPackUI;
        
        [SerializeField]
        private EventButton _pauseButton;

        [SerializeField]
        private FieldSettings _filedSettings;
        
        [SerializeField]
        private CanvasScaler _canvasScaler;

        [SerializeField]
        private RectTransform _headerTransform;
        
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
            var height = _canvasScaler.referenceResolution.y * _filedSettings.TopOffset;
            _headerTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
        }
        
        private void OnPauseButtonPressed()
        {
            EventBus.RaiseEvent<IPauseGameHandler>(a => a.OnPause());
        }

        public void OnPrepareGame()
        {
            var currentPack = PacksManager.Instance.GetCurrentPackInfo();
            _headerPackUI.SetPackImage(currentPack.GamePack.Icon);
            _headerPackUI.SetLevelText(currentPack.CurrentLevel.ToString());
        }
    }
}