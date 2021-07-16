using Project.Scripts.EventInterfaces.GameEvents;
using Project.Scripts.EventInterfaces.PacksEvents;
using Project.Scripts.EventInterfaces.StatesEvents;
using Project.Scripts.Packs.Data.Packs;
using Project.Scripts.UI.UIElements;
using Project.Scripts.Utils.EventSystem;
using Project.Scripts.Utils.Localization.UILocalization;
using Project.Scripts.Utils.UI.Button;
using Project.Scripts.Utils.UI.Popup.Abstract;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.UI.Popups
{
    public class WinPopup : AbstractPopup, IPackChangedHandler
    {
        [SerializeField]
        private Image _packImage;
        
        [SerializeField]
        private TMProCustomTextLocalization _packText;

        [SerializeField]
        private EventButton _nextButton;
        
        [SerializeField]
        private Slider _slider;

        private bool _isSwitchPack;
        
        public override void Initialize()
        {
            base.Initialize();
            _nextButton.OnButtonPressed += OnContinueButtonPressed;
            
            EventBus.Subscribe(this);
        }

        protected override void StartPopup()
        {
            _nextButton.Enable();
        }

        protected override void ResetPopup()
        {
            _nextButton.Disable();
        }

        public void OnPackChanged(PackInfo currentPack)
        {
            _packImage.sprite = currentPack.GamePack.Icon;
            _packText.SetTranslationName(currentPack.GamePack.Key);
            _slider.maxValue = currentPack.GamePack.LevelCount + 1;
            _slider.value = currentPack.CurrentLevel;
            _isSwitchPack = currentPack.IsSwitchToNextPack && !currentPack.IsLastPack;
        }

        private void OnContinueButtonPressed()
        {
            if (_isSwitchPack)
            {
                EventBus.RaiseEvent<IStartGameHandler>(a => a.OnStartGameProcess());   
            }
            else
            {
                EventBus.RaiseEvent<IPacksUIHandler>(a => a.OnStartChoosePack());
            }
        }
    }
}