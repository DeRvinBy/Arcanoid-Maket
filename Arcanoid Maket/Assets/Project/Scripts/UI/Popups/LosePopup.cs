using Project.Scripts.EventInterfaces.GameEvents;
using Project.Scripts.UI.UIElements;
using Project.Scripts.Utils.EventSystem;
using Project.Scripts.Utils.UI.Button;
using Project.Scripts.Utils.UI.Popup.Abstract;
using UnityEngine;

namespace Project.Scripts.UI.Popups
{
    public class LosePopup : AbstractPopup
    {
        [SerializeField]
        private EventButton _restartButton;

        public override void Initialize()
        {
            base.Initialize();
            _restartButton.Initialize();
            _restartButton.OnButtonPressed += OnRestartButtonPressed;
        }

        protected override void StartPopup()
        {
            _restartButton.Enable();
        }

        protected override void ResetPopup()
        {
            _restartButton.Disable();
        }

        private void OnRestartButtonPressed()
        {
            EventBus.RaiseEvent<IStartGameHandler>(a => a.OnStartGameProcess());
        }
    }
}