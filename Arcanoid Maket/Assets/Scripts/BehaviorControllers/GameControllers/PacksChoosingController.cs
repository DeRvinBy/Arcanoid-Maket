using BehaviorControllers.Abstract;
using EventInterfaces.StatesEvents;
using GamePacks;
using MyLibrary.EventSystem;
using MyLibrary.UI.Popup;
using UI.Popups;

namespace BehaviorControllers.GameControllers
{
    public class PacksChoosingController : GameController, IPacksChoosingHandler
    {
        private PopupsController _popupsController;

        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(this);
        }
        
        public override void Initialize(ControllersManager controllersManager)
        {
            _popupsController = controllersManager.GetEntityController<PopupsController>();
        }

        public void OnStartChoosePack()
        {
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