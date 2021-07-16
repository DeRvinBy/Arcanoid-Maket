using Project.Scripts.EventInterfaces.PacksEvents;
using Project.Scripts.EventInterfaces.StatesEvents;
using Project.Scripts.Packs.Data.Packs;
using Project.Scripts.UI.UIElements;
using Project.Scripts.Utils.EventSystem;
using Project.Scripts.Utils.Localization.UILocalization;
using Project.Scripts.Utils.UI.Button;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.UI.Header
{
    public class HeaderUI : MonoBehaviour, IStartGameplayHandler, IEndGameplayHandler, IPackChangedHandler
    {
        [SerializeField]
        private Image _packImage;
        
        [SerializeField]
        private TMProValueLocalization _levelText;

        [SerializeField]
        private EventButton _pauseButton;

        private void Awake()
        {
            _pauseButton.OnButtonPressed += OnPauseButtonPressed;
        }
        
        private void OnPauseButtonPressed()
        {
            EventBus.RaiseEvent<IPauseGameHandler>(a => a.OnPause());
        }

        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(this);
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
            _packImage.sprite = currentPack.GamePack.Icon;
            _levelText.SetValue(currentPack.CurrentLevel.ToString());
        }
    }
}