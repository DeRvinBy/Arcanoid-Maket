using Project.Scripts.EventInterfaces.StatesEvents;
using Project.Scripts.GameEntities.PlayerLocalization;
using Project.Scripts.Utils.EventSystem;
using Project.Scripts.Utils.UI.Button;
using Project.Scripts.Utils.UI.Popup.Abstract;
using UnityEngine;

namespace Project.Scripts.UI.Popups
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
            _playButton.OnButtonPressed += OnPlayButtonPressed;
        }

        protected override void StartPopup()
        {
            _playButton.Enable();
            _selector.Enable();
        }

        protected override void ResetPopup()
        {
            _playButton.Disable();
            _selector.Disable();
        }

        private void OnPlayButtonPressed()
        {
            EventBus.RaiseEvent<IPacksUIHandler>(a => a.OnStartChoosePack());
        }
    }
}