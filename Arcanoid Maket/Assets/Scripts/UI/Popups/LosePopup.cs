using EventInterfaces.GameEvents;
using Library.EventSystem;
using Library.UI.Button;
using Library.UI.Popup.Abstract;
using UnityEngine;

namespace UI.Popups
{
    public class LosePopup : AbstractPopup
    {
        [SerializeField]
        private EventButton _restartButton;

        protected override void StartPopup()
        {
            _restartButton.Enable();
            _restartButton.OnButtonPressed += OnRestartButtonPressed;
        }

        protected override void ResetPopup()
        {
            _restartButton.Disable();
            _restartButton.OnButtonPressed -= OnRestartButtonPressed;
        }

        private void OnRestartButtonPressed()
        {
            EventBus.RaiseEvent<IStartGameHandler>(a => a.OnStartGameProcess());
        }
    }
}