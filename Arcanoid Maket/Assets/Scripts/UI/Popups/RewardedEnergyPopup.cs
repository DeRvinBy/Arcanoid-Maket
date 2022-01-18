using Ads;
using GameComponents.Energy.Commands;
using GameComponents.Energy.Enumerations;
using MyLibrary.EnergySystem;
using MyLibrary.UI.Button;
using MyLibrary.UI.Popup;
using MyLibrary.UI.Popup.Abstract;
using UnityEngine;

namespace UI.Popups
{
    public class RewardedEnergyPopup : AbstractPopup
    {
        [SerializeField] 
        private EventButton _rewardedButton;
        
        [SerializeField] 
        private GameObject _rewardedButtonLocker;
        
        [SerializeField] 
        private EventButton _laterButton;
        
        private AddEnergyCommand _addRewardedEnergy;
        
        public override void Initialize()
        {
            base.Initialize();
            _rewardedButton.OnButtonPressed += OnRewardedButtonPressed;
            _laterButton.OnButtonPressed += OnLaterButtonPressed;
            
            _addRewardedEnergy = new AddEnergyCommand();
            EnergyManager.Instance.SetupCommandWithEnergy(_addRewardedEnergy, (int)TypeActionForEnergy.Rewarded);
        }

        protected override void PreparePopup()
        {
            _rewardedButtonLocker.SetActive(true);
            AdsController.Instance.RewardedAdService.LoadAd(OnRewardedAdLoad);
        }

        private void OnRewardedAdLoad(bool isLoad)
        {
            _rewardedButtonLocker.SetActive(false);
        }

        private void OnRewardedButtonPressed()
        {
            AdsController.Instance.RewardedAdService.ShowAd(OnRewardedVideoComplete);
        }

        private void OnRewardedVideoComplete()
        {
            _addRewardedEnergy.Execute();
            StartCoroutine(PopupsController.Instance.HideLastPopup());
        }
        
        private void OnLaterButtonPressed()
        {
            StartCoroutine(PopupsController.Instance.HideLastPopup());
        }
    }
}