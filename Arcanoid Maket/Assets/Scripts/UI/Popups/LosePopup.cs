using EventInterfaces.GameEvents;
using MyLibrary.EventSystem;
using MyLibrary.UI.Button;
using MyLibrary.UI.Popup.Abstract;
using UnityEngine;

namespace UI.Popups
{
    public class LosePopup : AbstractPopup
    {
        [SerializeField]
        private EventButton _restartButton;

        public override void Initialize()
        {
            base.Initialize();
            _restartButton.OnButtonPressed += OnRestartButtonPressed;
        }

        private void OnRestartButtonPressed()
        {
            EventBus.RaiseEvent<IStartGameHandler>(a => a.OnRestartGameProcess());
        }
    }
}