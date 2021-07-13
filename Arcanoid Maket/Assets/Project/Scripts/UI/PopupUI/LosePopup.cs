using Project.Scripts.EventInterfaces.GameEvents;
using Project.Scripts.UI.PopupUI.Abstract;
using Project.Scripts.UI.UIElements;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.UI.PopupUI
{
    public class LosePopup : Popup
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

        public void OnRestartButtonPressed()
        {
            EventBus.RaiseEvent<IStartGameHandler>(a => a.OnStartGameProcess());
        }
    }
}