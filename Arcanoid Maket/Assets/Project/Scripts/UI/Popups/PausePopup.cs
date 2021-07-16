using Project.Scripts.EventInterfaces.GameEvents;
using Project.Scripts.EventInterfaces.StatesEvents;
using Project.Scripts.UI.UIElements;
using Project.Scripts.Utils.EventSystem;
using Project.Scripts.Utils.UI.Button;
using Project.Scripts.Utils.UI.Popup.Abstract;
using UnityEngine;

namespace Project.Scripts.UI.Popups
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
            EventBus.RaiseEvent<IPauseGameHandler>(a => a.OnContinue());
            EventBus.RaiseEvent<IStartGameHandler>(a => a.OnStartGameProcess());
        }

        private void OnBackButtonPressed()
        {
            EventBus.RaiseEvent<IPacksUIHandler>(a => a.OnStartChoosePack());
        }

        private void OnContinueButtonPressed()
        {
            EventBus.RaiseEvent<IPauseGameHandler>(a => a.OnContinue());
        }
    }
}