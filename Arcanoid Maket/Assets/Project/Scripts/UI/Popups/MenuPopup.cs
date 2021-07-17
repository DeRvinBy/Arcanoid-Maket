using Project.Scripts.GameEntities.PlayerLocalization;
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
        
        public override void Initialize()
        {
            base.Initialize();
            _playButton.OnButtonPressed += OnPlayButtonPressed;
            _playButton.Disable();
            _selector.Disable();
        }

        protected override void StartPopup()
        {
            _playButton.Enable();
            _selector.Enable();
        }

        private void OnPlayButtonPressed()
        {
            
        }
    }
}