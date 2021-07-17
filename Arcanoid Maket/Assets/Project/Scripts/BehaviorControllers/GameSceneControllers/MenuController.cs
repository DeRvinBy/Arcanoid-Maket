using Project.Scripts.BehaviorControllers.Abstract;
using Project.Scripts.UI.Popups;
using Project.Scripts.Utils.UI.Popup;

namespace Project.Scripts.BehaviorControllers.GameSceneControllers
{
    public class MenuController : GameController
    {
        private PopupsController _popupsController;
        
        public override void Initialize(ControllersManager controllersManager)
        {
            base.Initialize(controllersManager);
            _popupsController = controllersManager.GetEntityController<PopupsController>();
        }

        private void Start()
        {
            StartCoroutine(_popupsController.ShowPopup<MenuPopup>());
        }
    }
}