using Project.Scripts.BehaviorControllers.Abstract;
using Project.Scripts.EventInterfaces.GameEvents.UIEvents;
using Project.Scripts.Packs;
using Project.Scripts.UI.Popups;
using Project.Scripts.Utils.EventSystem;
using Project.Scripts.Utils.UI.Popup;

namespace Project.Scripts.BehaviorControllers.GameSceneControllers
{
    public class UIPacksChoosing : GameController, IPacksUIHandler
    {
        private PopupsController _popupsController;
        private PacksController _packsController;
        
        public override void Initialize(ControllersManager controllersManager)
        {
            _popupsController = controllersManager.GetEntityController<PopupsController>();
            _packsController = controllersManager.GetEntityController<PacksController>();
            
            EventBus.Subscribe(this);
        }
        
        public void OnStartChoosePack()
        {
            _packsController.UpdatePacksInfo();
            StartCoroutine(_popupsController.ShowPopup<PackChoosingPopup>());
        }

        public void OnPackChoose()
        {
            StartCoroutine(_popupsController.HideAllActivePopups());
        }

        public void OnCancelChoosePack()
        {
            StartCoroutine(_popupsController.HideLastPopup());
        }
    }
}