using EventInterfaces.PacksEvents;
using EventInterfaces.StatesEvents;
using GamePacks.Data.Packs;
using GameSettings.PackContainerSettings;
using Library.EventSystem;
using Library.ObjectPool.Abstract;
using UnityEngine;

namespace UI.Packs.PackItem
{
    public class PackContainerEntity : PoolObject
    {
        [SerializeField]
        private PackContainerUI _containerUI;

        private DefaultPackContainerSettings _defaultSettings;

        public void Initialize(DefaultPackContainerSettings settings)
        {
            _defaultSettings = settings;
        }
        
        public void SetupDefaultContainer(PackInfo packInfo)
        {
            _containerUI.SetButtonInteractable(false);
            _containerUI.SetButtonColor(_defaultSettings.ButtonColor);
            _containerUI.SetPackIcon(_defaultSettings.PackIcon);
            _containerUI.SetPackName(_defaultSettings.PackKey);
            _containerUI.SetLevels(_defaultSettings.CurrentLevel, packInfo.GamePack.LevelCount);
        }

        public void SetupPackContainer(PackInfo packInfo)
        {
            var pack = packInfo.GamePack;
            _containerUI.SetButtonInteractable(true);
            _containerUI.SetButtonCallback(() => OnPackButtonPressed(pack.Key));
            _containerUI.SetButtonColor(pack.Color);
            _containerUI.SetPackIcon(pack.Icon);
            _containerUI.SetPackName(pack.Key); ;
            _containerUI.SetLevels(packInfo.PackProgressLevel, pack.LevelCount);
        }

        private void OnPackButtonPressed(string packKey)
        {
            EventBus.RaiseEvent<IPacksChoosingHandler>(a => a.OnPackChoose(packKey));
            EventBus.RaiseEvent<IPackButtonPressedHandler>(a => a.OnPackButtonPressed());
        }
    }
}