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
        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(this);
        }

        public void OnStartChoosePack()
        {
            StartCoroutine(PopupsController.Instance.ShowPopup<PackChoosingPopup>());
        }

        public void OnPackChoose(string packKey)
        {
            PacksManager.Instance.SetCurrentPack(packKey);
        }

        public void OnCancelChoosePack()
        {
            StartCoroutine(PopupsController.Instance.HideLastPopup());
        }
    }
}