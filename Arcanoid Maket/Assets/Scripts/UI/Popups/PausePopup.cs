using EventInterfaces.GameEvents;
using EventInterfaces.StatesEvents;
using MyLibrary.EventSystem;
using MyLibrary.UI.Button;
using MyLibrary.UI.Popup.Abstract;
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
            _restartButton.OnButtonPressed += OnRestartButtonPressed;
            _backButton.OnButtonPressed += OnBackButtonPressed;
            _continueButton.OnButtonPressed += OnContinueButtonPressed;
        }
        
        protected override void ResetPopup()
        {
            _restartButton.OnButtonPressed -= OnRestartButtonPressed;
            _backButton.OnButtonPressed -= OnBackButtonPressed;
            _continueButton.OnButtonPressed -= OnContinueButtonPressed;
        }

        private void OnRestartButtonPressed()
        {
            EventBus.RaiseEvent<IPauseGameHandler>(a => a.OnStartTime());
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