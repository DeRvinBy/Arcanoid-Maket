using System;
using Project.Scripts.EventInterfaces.PacksEvents;
using Project.Scripts.Packs.Data.Game;
using Project.Scripts.Packs.EventArguments;
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

        public void OnLevelChanged(LevelArguments levelArguments)
        {
            var currentLevel = levelArguments.CurrentLevel.ToString();
            _levelText.SetValue(currentLevel);
        }

        public void OnPackChanged(Pack currentPack)
        {
            _packImage.sprite = currentPack.Icon;
        }
    }
}