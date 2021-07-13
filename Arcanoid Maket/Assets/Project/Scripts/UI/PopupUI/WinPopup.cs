using Project.Scripts.EventInterfaces.GameEvents;
using Project.Scripts.EventInterfaces.PacksEvents;
using Project.Scripts.Packs.Data.Packs;
using Project.Scripts.UI.PopupUI.Abstract;
using Project.Scripts.UI.UIElements;
using Project.Scripts.Utils.EventSystem;
using Project.Scripts.Utils.Localization.UILocalization;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.UI.PopupUI
{
    public class WinPopup : Popup, IPackChangedHandler, ILevelChangedHandler
    {
        [SerializeField]
        private Image _packImage;
        
        [SerializeField]
        private TMProCustomTextLocalization _packText;

        [SerializeField]
        private EventButton _nextButton;
        
        [SerializeField]
        private Slider _slider;

        public override void Initialize()
        {
            base.Initialize();
            _nextButton.Initialize();
            _nextButton.OnButtonPressed += OnContinueButtonPressed;
            
            EventBus.Subscribe(this);
        }

        protected override void StartPopup()
        {
            EventBus.RaiseEvent<ILevelCompleteHandler>(a => a.OnLevelComplete());
            _nextButton.Enable();
        }

        protected override void ResetPopup()
        {
            _nextButton.Disable();
        }

        public void OnPackChanged(Pack currentPack)
        {
            _packImage.sprite = currentPack.Icon;
            _packText.SetTranslationName(currentPack.Key);
            _slider.maxValue = currentPack.LevelCount + 1;
        }

        public void OnLevelChanged(int currentLevel)
        {
            _slider.value = currentLevel;
        }

        public void OnContinueButtonPressed()
        {
            EventBus.RaiseEvent<IStartGameHandler>(a => a.OnStartGameProcess());
        }
    }
}