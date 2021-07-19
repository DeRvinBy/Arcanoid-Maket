using Scripts.BehaviorControllers.EntitiesControllers;
using Scripts.EventInterfaces.StatesEvents;
using Scripts.UI.Menu;
using Scripts.Utils.EventSystem;
using Scripts.Utils.UI.Button;
using Scripts.Utils.UI.Popup.Abstract;
using UnityEngine;

namespace Scripts.UI.Popups
{
    public class MenuPopup : AbstractPopup
    {
        [SerializeField]
        private EventButton _playButton;

        [SerializeField]
        private LanguageSelectorUI _selector;

        private LocalizationController _localization;
        
        public override void Initialize()
        {
            base.Initialize();
            _localization = new LocalizationController();
            _localization.Initialize(_selector);
            
            _playButton.Disable();
            _selector.Disable();
        }

        protected override void StartPopup()
        {
            _playButton.Enable();
            _selector.Enable();
            _playButton.OnButtonPressed += OnPlayButtonPressed;
        }

        protected override void ResetPopup()
        {
            _playButton.Disable();
            _selector.Disable();
            _playButton.OnButtonPressed -= OnPlayButtonPressed;
        }

        private void OnPlayButtonPressed()
        {
            EventBus.RaiseEvent<IStartGameplayHandler>(a => a.OnStartGame());
        }
    }
}