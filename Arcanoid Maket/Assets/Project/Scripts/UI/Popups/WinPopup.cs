using Project.Scripts.EventInterfaces.GameEvents;
using Project.Scripts.EventInterfaces.PacksEvents;
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
    public class WinPopup : AbstractPopup, IPackChangedHandler, ILevelChangedHandler
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

        private void OnContinueButtonPressed()
        {
            EventBus.RaiseEvent<IStartGameHandler>(a => a.OnStartGameProcess());
        }
    }
}