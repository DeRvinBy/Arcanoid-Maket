using Project.Scripts.BehaviorControllers.Abstract;
using Project.Scripts.EventInterfaces.GameEvents;
using Project.Scripts.EventInterfaces.StatesEvents;
using Project.Scripts.Packs;
using Project.Scripts.UI.Popups;
using Project.Scripts.Utils.EventSystem;
using Project.Scripts.Utils.UI.Popup;
using UnityEngine;

namespace Project.Scripts.BehaviorControllers.GameSceneControllers
{
    public class UIPacksChoosing : GameController, IPacksUIHandler
    {
        [SerializeField]
        private string _debugPack = "test_pack";
        
        private PopupsController _popupsController;
        private PacksController _packsController;
        
        public override void Initialize(ControllersManager controllersManager)
        {
            _popupsController = controllersManager.GetEntityController<PopupsController>();
            _packsController = controllersManager.GetEntityController<PacksController>();
            _packsController.SetCurrentPack(_debugPack);
            
            EventBus.Subscribe(this);
        }
        
        public void OnStartChoosePack()
        {
            _packsController.UpdatePacksInfo();
            StartCoroutine(_popupsController.ShowPopup<PackChoosingPopup>());
        }

        public void OnPackChoose(string packKey)
        {
            _packsController.SetCurrentPack(packKey);
            EventBus.RaiseEvent<IPauseGameHandler>(a => a.OnContinue());
            EventBus.RaiseEvent<IStartGameHandler>(a => a.OnStartGameProcess());
        }

        public void OnCancelChoosePack()
        {
            StartCoroutine(_popupsController.HideLastPopup());
        }
    }
}