using Scripts.BehaviorControllers.Abstract;
using Scripts.EventInterfaces.PacksEvents;
using Scripts.EventInterfaces.StatesEvents;
using Scripts.GamePacks.Data.Packs;
using Scripts.UI.Header.PackUI;
using Scripts.Utils.EventSystem;
using Scripts.Utils.UI.Button;
using UnityEngine;

namespace Scripts.UI.Header
{
    public class HeaderController : EntityController, IStartGameplayHandler, IEndGameplayHandler, IPackChangedHandler
    {
        [SerializeField]
        private HeaderPackUI _headerPackUI;
        
        [SerializeField]
        private EventButton _pauseButton;
        
        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(this);
        }

        public override void Initialize()
        {
            _pauseButton.OnButtonPressed += OnPauseButtonPressed;
        }
        
        private void OnPauseButtonPressed()
        {
            EventBus.RaiseEvent<IPauseGameHandler>(a => a.OnPause());
        }

        public void OnStartGame()
        {
            _pauseButton.Enable();
        }

        public void OnEndGame()
        {
            _pauseButton.Disable();
        }

        public void OnPackChanged(PackInfo currentPack)
        {
            _headerPackUI.SetPackImage(currentPack.GamePack.Icon);
            _headerPackUI.SetLevelText(currentPack.CurrentLevel.ToString());
        }
    }
}