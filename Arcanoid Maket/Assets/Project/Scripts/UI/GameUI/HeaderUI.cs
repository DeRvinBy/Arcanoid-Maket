using System;
using Project.Scripts.EventInterfaces.PacksEvents;
using Project.Scripts.EventInterfaces.StatesEvents;
using Project.Scripts.Packs.Data.Packs;
using Project.Scripts.UI.UIElements;
using Project.Scripts.Utils.EventSystem;
using Project.Scripts.Utils.Localization.UILocalization;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.UI.GameUI
{
    public class HeaderUI : MonoBehaviour, IStartGameplayHandler, IEndGameplayHandler, ILevelChangedHandler, IPackChangedHandler
    {
        [SerializeField]
        private Image _packImage;
        
        [SerializeField]
        private TMProValueLocalization _levelText;

        [SerializeField]
        private EventButton _pauseButton;

        private void Awake()
        {
            _pauseButton.Initialize();
            _pauseButton.OnButtonPressed += OnPauseButtonPressed;
        }
        
        private void OnPauseButtonPressed()
        {
            EventBus.RaiseEvent<IPauseGameHandler>(a => a.OnPause());
        }

        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(this);
        }
        
        public void OnStartGame()
        {
            _pauseButton.Enable();
        }
        
        public void OnEndGame()
        {
            _pauseButton.Disable();
        }

        public void OnLevelChanged(int currentLevel)
        {
            _levelText.SetValue(currentLevel.ToString());
        }

        public void OnPackChanged(Pack currentPack)
        {
            _packImage.sprite = currentPack.Icon;
        }
    }
}