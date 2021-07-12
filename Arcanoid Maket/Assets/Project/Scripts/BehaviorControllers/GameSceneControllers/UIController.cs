using Project.Scripts.BehaviorControllers.Abstract;
using Project.Scripts.EventInterfaces.GameEvents;
using Project.Scripts.UI.PopupUI;
using Project.Scripts.Utils.EventSystem;

namespace Project.Scripts.BehaviorControllers.GameSceneControllers
{
    public class UIController : Abstract.GameController, IEndGameHandler
    {
        private PopupsController _popupsController;

        public override void Initialize(ControllersManager controllersManager)
        {
            _popupsController = controllersManager.GetEntityController<PopupsController>();

            EventBus.Subscribe(this);
        }

        public void OnWinGame()
        {
            _popupsController.ShowPopup<WinPopup>();
        }

        public void OnLoseGame()
        {
            _popupsController.ShowPopup<LosePopup>();
        }
    }
}