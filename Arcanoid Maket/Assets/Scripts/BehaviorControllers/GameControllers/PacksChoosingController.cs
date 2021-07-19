using Scripts.BehaviorControllers.Abstract;
using Scripts.EventInterfaces.StatesEvents;
using Scripts.GamePacks;
using Scripts.UI.Popups;
using Scripts.Utils.EventSystem;
using Scripts.Utils.UI.Popup;

namespace Scripts.BehaviorControllers.GameControllers
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