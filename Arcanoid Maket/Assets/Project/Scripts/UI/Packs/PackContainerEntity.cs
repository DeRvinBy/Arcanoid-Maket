using Project.Scripts.EventInterfaces.GameEvents.UIEvents;
using Project.Scripts.GameSettings.PackContainerSettings;
using Project.Scripts.Packs.Data.Packs;
using Project.Scripts.Utils.EventSystem;
using Project.Scripts.Utils.ObjectPool.Abstract;
using UnityEngine;

namespace Project.Scripts.UI.Packs
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
            _containerUI.AddButtonCallback(
                () => EventBus.RaiseEvent<IPacksUIHandler>(a => a.OnPackChoose(pack.Key)));
            _containerUI.SetButtonColor(pack.Color);
            _containerUI.SetPackIcon(pack.Icon);
            _containerUI.SetPackName(pack.Key);
            _containerUI.SetLevels(packInfo.CurrentLevelInPack, pack.LevelCount);
        }
    }
}