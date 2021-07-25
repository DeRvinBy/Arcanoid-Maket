using EventInterfaces.StatesEvents;
using GamePacks;
using MyLibrary.EventSystem;
using MyLibrary.UI.Button;
using MyLibrary.UI.Popup.Abstract;
using UI.Packs;
using UnityEngine;

namespace UI.Popups
{
    public class PackChoosingPopup : AbstractPopup
    {
        [SerializeField]
        private UIPacksManager _manager;

        [SerializeField]
        private EventButton _backButton;

        public override void Initialize()
        {
            base.Initialize();
            _backButton.OnButtonPressed += OnBack;
        }

        protected override void PreparePopup()
        {
            var packsInfo = PacksManager.Instance.GetPacksInfo();
            _manager.UpdatePackContainers(packsInfo);
        }

        private void OnBack()
        {
            EventBus.RaiseEvent<IPacksChoosingHandler>(a => a.OnCancelChoosePack());
        }
    }
}