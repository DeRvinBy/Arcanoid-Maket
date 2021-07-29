using EventInterfaces.GameEvents;
using EventInterfaces.StatesEvents;
using MyLibrary.EventSystem;
using MyLibrary.Extensions;
using MyLibrary.UI.Button;
using MyLibrary.UI.Popup.Abstract;
using UnityEngine;

namespace UI.Popups
{
    public class LosePopup : AbstractPopup, IStartGameplayHandler
    {
        [SerializeField]
        private EventButton _restartButton;

        [SerializeField]
        private GameObject _newBallButtonContainer;
        
        [SerializeField]
        private EventButton _newBallButton;

        private bool _isAdditionalBallUsed;
        
        public override void Initialize()
        {
            base.Initialize();
            _restartButton.OnButtonPressed += OnRestartButtonPressed;
            _newBallButton.OnButtonPressed += OnNewBallButtonPressed;
            EventBus.Subscribe(this);
        }

        protected override void PreparePopup()
        {
            _newBallButtonContainer.SetActive(!_isAdditionalBallUsed);
        }

        private void OnNewBallButtonPressed()
        {
            _isAdditionalBallUsed = true;
            EventBus.RaiseEvent<IStartGameHandler>(a => a.OnContinueAfterLoseGameProcess());
        }

        private void OnRestartButtonPressed()
        {
            EventBus.RaiseEvent<IStartGameHandler>(a => a.OnRestartGameProcess());
        }

        public void OnStartGame()
        {
            _isAdditionalBallUsed = false;
        }
    }
}