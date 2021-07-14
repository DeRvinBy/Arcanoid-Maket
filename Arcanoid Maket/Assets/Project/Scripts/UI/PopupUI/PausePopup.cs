using Project.Scripts.EventInterfaces.GameEvents;
using Project.Scripts.EventInterfaces.StatesEvents;
using Project.Scripts.UI.PopupUI.Abstract;
using Project.Scripts.UI.UIElements;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.UI.PopupUI
{
    public class PausePopup : AbstractPopup
    {
        [SerializeField]
        private EventButton _restartButton;
        
        [SerializeField]
        private EventButton _backButton;
        
        [SerializeField]
        private EventButton _continueButton;

        public override void Initialize()
        {
            base.Initialize();
            _restartButton.Initialize();
            _backButton.Initialize();
            _continueButton.Initialize();
            
            _restartButton.OnButtonPressed += OnRestartButtonPressed;
            _backButton.OnButtonPressed += OnBackButtonPressed;
            _continueButton.OnButtonPressed += OnContinueButtonPressed;
        }

        protected override void StartPopup()
        {
            _restartButton.Enable();
            _backButton.Enable();
            _continueButton.Enable();
        }
        
        protected override void ResetPopup()
        {
            _restartButton.Disable();
            _backButton.Disable();
            _continueButton.Disable();
        }

        private void OnRestartButtonPressed()
        {
            print("Restart button");
            EventBus.RaiseEvent<IPauseGameHandler>(a => a.OnContinue());
            EventBus.RaiseEvent<IStartGameHandler>(a => a.OnStartGameProcess());
        }

        private void OnBackButtonPressed()
        {
            print("chose pack");
        }

        private void OnContinueButtonPressed()
        {
            EventBus.RaiseEvent<IPauseGameHandler>(a => a.OnContinue());
        }
    }
}