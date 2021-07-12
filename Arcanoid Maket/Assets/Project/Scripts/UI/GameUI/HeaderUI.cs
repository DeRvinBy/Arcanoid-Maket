using Project.Scripts.EventInterfaces.PacksEvents;
using Project.Scripts.Packs.Data.Packs;
using Project.Scripts.Utils.EventSystem;
using Project.Scripts.Utils.Localization.UILocalization;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.UI.GameUI
{
    public class HeaderUI : MonoBehaviour, ILevelChangedHandler, IPackChangedHandler
    {
        [SerializeField]
        private Image _packImage;
        
        [SerializeField]
        private TMProValueLocalization _levelText;
        
        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(this);
        }

        public void OnLevelChanged(int currentLevel)
        {
            _levelText.SetValue(currentLevel.ToString());
        }

        public void OnPackChanged(Pack currentPack)
        {
            _packImage.sprite = currentPack.Icon;
        }
    }
}