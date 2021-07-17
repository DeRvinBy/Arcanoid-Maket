using System;
using Project.Scripts.BehaviorControllers.Abstract;
using Project.Scripts.EventInterfaces.GameEvents;
using Project.Scripts.EventInterfaces.StatesEvents;
using Project.Scripts.Packs;
using Project.Scripts.UI.Popups;
using Project.Scripts.Utils.EventSystem;
using Project.Scripts.Utils.UI.Popup;

namespace Project.Scripts.BehaviorControllers.GameSceneControllers
{
    public class UIPacksChoosing : GameController, IPacksUIHandler
    {
        private PopupsController _popupsController;

        public override void Initialize(ControllersManager controllersManager)
        {
            _popupsController = controllersManager.GetEntityController<PopupsController>();

            EventBus.Subscribe(this);
        }

        private void OnDestroy()
        {
            EventBus.Unsubscribe(this);
        }

        public void OnStartChoosePack()
        {
            PacksManager.Instance.UpdatePacksInfo();
            StartCoroutine(_popupsController.ShowPopup<PackChoosingPopup>());
        }

        public void OnPackChoose(string packKey)
        {
            PacksManager.Instance.SetCurrentPack(packKey);
        }

        public void OnCancelChoosePack()
        {
            StartCoroutine(_popupsController.HideLastPopup());
        }
    }
}