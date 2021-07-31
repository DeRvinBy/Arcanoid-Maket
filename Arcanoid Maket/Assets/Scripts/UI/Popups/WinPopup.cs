using EventInterfaces.GameEvents;
using EventInterfaces.PacksEvents;
using EventInterfaces.StatesEvents;
using GameComponents.Energy.Commands;
using GameComponents.Energy.Enumerations;
using GameComponents.Energy.UI;
using GamePacks;
using GamePacks.Data.Packs;
using MyLibrary.EnergySystem;
using MyLibrary.EventSystem;
using MyLibrary.UI.Button;
using MyLibrary.UI.Popup.Abstract;
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
        
        private PackInfo _currentPack;
        private bool _isNeedChoosePack;

        public override void Initialize()
        {
            base.Initialize();
            _nextButton.OnButtonPressed += OnContinueButtonPressed;
            EventBus.Subscribe(this);
            SetupPackUI();
        }

        protected override void PreparePopup()
        {
            _popupPackUI.PreparePackUI();
        }

        protected override void StartPopup()
        {
            UpdatePackUI();
        }

        private void SetupPackUI()
        {
            _currentPack = PacksManager.Instance.GetCurrentPackInfo();
            if (_currentPack == null) return;
            _popupPackUI.SetPackImage(_currentPack.GamePack.Icon);
            _popupPackUI.SetPackName(_currentPack.GamePack.Key);
            var maxValue = _currentPack.GamePack.LevelCount + 1;
            var currentLevel = _currentPack.CurrentLevel;
            _popupPackUI.SetupSlider(currentLevel, maxValue);
        }

        private void UpdatePackUI()
        {
            var pack = PacksManager.Instance.GetCurrentPackInfo();
            if (_currentPack == pack)
            {
                _isNeedChoosePack = _currentPack.IsPackReplayed || _currentPack.IsLastPack;
                if (_isNeedChoosePack)
                {
                    _popupPackUI.UpdatePackProgress(_currentPack.GamePack.LevelCount + 1, null);
                }
                else
                {
                    _popupPackUI.UpdatePackProgress(_currentPack.CurrentLevel, null);
                }
                _popupPackUI.UpdateContinueButton(!_isNeedChoosePack);
            }
            else
            {
                _popupPackUI.UpdatePackProgress(_currentPack.GamePack.LevelCount + 1, SetupPackUI);
            }
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

        public void OnPackChanged()
        {
            SetupPackUI();
        }
    }
}