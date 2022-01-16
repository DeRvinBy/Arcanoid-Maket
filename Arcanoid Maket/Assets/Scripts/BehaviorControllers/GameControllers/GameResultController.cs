using System.Collections;
using Ads;
using BehaviorControllers.Abstract;
using EventInterfaces.GameEvents;
using GameComponents.Energy.Commands;
using GameComponents.Energy.Enumerations;
using GamePacks;
using MyLibrary.EnergySystem;
using MyLibrary.EventSystem;
using MyLibrary.UI.Popup;
using UI.Popups;

namespace BehaviorControllers.GameControllers
{
    public class GameResultController : GameController, IEndGameHandler
    {
        private AddEnergyCommand _addEnergyOnWin;

        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(this);
        }
        private void Start()
        {
            _addEnergyOnWin = new AddEnergyCommand();
            EnergyManager.Instance.SetupCommandWithEnergy(_addEnergyOnWin, (int)TypeActionForEnergy.WinGame);
        }
        
        public void OnWinGame()
        {
            StartCoroutine(WinGame());
        }

        private IEnumerator WinGame()
        {
            PacksManager.Instance.CompleteLevel();
            yield return PopupsController.Instance.ShowPopup<WinPopup>(OnWinPopupShown);
        }

        private void OnWinPopupShown()
        {
             AdsController.Instance.InterstitialAdService.ShowAd(_addEnergyOnWin.Execute);
        }

        public void OnLoseGame()
        {
            StartCoroutine(PopupsController.Instance.ShowPopup<LosePopup>());
        }
    }
}