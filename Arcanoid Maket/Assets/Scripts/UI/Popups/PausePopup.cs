using EventInterfaces.GameEvents;
using EventInterfaces.StatesEvents;
using Library.EventSystem;
using Library.UI.Button;
using Library.UI.Popup.Abstract;
using UnityEngine;

namespace UI.Popups
{
    public class PausePopup : AbstractPopup
    {
        [SerializeField]
        private EventButton _restartButton;
        
        [SerializeField]
        private EventButton _backButton;
        
        [SerializeField]
        private EventButton _continueButton;

        protected override void StartPopup()
        {
            _restartButton.Enable();
            _backButton.Enable();
            _continueButton.Enable();
            
            _restartButton.OnButtonPressed += OnRestartButtonPressed;
            _backButton.OnButtonPressed += OnBackButtonPressed;
            _continueButton.OnButtonPressed += OnContinueButtonPressed;
        }
        
        protected override void ResetPopup()
        {
            _restartButton.Disable();
            _backButton.Disable();
            _continueButton.Disable();
            
            _restartButton.OnButtonPressed -= OnRestartButtonPressed;
            _backButton.OnButtonPressed -= OnBackButtonPressed;
            _continueButton.OnButtonPressed -= OnContinueButtonPressed;
        }

        private void OnRestartButtonPressed()
        {
            EventBus.RaiseEvent<IPauseGameHandler>(a => a.OnContinue());
            EventBus.RaiseEvent<IStartGameHandler>(a => a.OnStartGameProcess());
        }

        private void OnBackButtonPressed()
        {
            EventBus.RaiseEvent<IPacksChoosingHandler>(a => a.OnStartChoosePack());
        }

        private void OnContinueButtonPressed()
        {
            EventBus.RaiseEvent<IPauseGameHandler>(a => a.OnContinue());
        }
    }
}