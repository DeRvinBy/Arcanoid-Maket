using EventInterfaces.GameEvents;
using EventInterfaces.PacksEvents;
using EventInterfaces.StatesEvents;
using GamePacks.Data.Packs;
using Library.EventSystem;
using Library.UI.Button;
using Library.UI.Popup.Abstract;
using UI.Packs;
using UnityEngine;

namespace UI.Popups
{
    public class WinPopup : AbstractPopup, IPackChangedHandler
    {
        [SerializeField]
        private WinPopupPackUI _popupPackUI;
        
        [SerializeField]
        private EventButton _nextButton;
        
        private bool _isNeedChoosePack;

        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(this);
        }

        protected override void StartPopup()
        {
            _nextButton.Enable();
            _nextButton.OnButtonPressed += OnContinueButtonPressed;
        }

        protected override void ResetPopup()
        {
            _nextButton.Disable();
            _nextButton.OnButtonPressed -= OnContinueButtonPressed;
        }

        public void OnPackChanged(PackInfo currentPack)
        {
            _popupPackUI.SetPackImage(currentPack.GamePack.Icon);
            _popupPackUI.SetPackName(currentPack.GamePack.Key);
            var maxValue = currentPack.GamePack.LevelCount + 1;
            var value = currentPack.CurrentLevel;
            _popupPackUI.UpdateSlider(value, maxValue);
            _isNeedChoosePack = currentPack.IsPackReplayed || currentPack.IsLastPack;
        }

        private void OnContinueButtonPressed()
        {
            if (_isNeedChoosePack)
            {
                EventBus.RaiseEvent<IPacksChoosingHandler>(a => a.OnStartChoosePack());
            }
            else
            {
                EventBus.RaiseEvent<IStartGameHandler>(a => a.OnStartGameProcess());   
            }
        }
    }
}