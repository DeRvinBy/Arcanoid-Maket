using Ads;
using EventInterfaces.GameEvents;
using EventInterfaces.StatesEvents;
using MyLibrary.EventSystem;
using MyLibrary.UI.Button;
using MyLibrary.UI.Popup.Abstract;
using UnityEngine;

namespace UI.Popups
{
    public class LosePopup : AbstractPopup, IStartGameplayHandler
    {
        [SerializeField]
        private EventButton _restartButton;

        [SerializeField]
        private GameObject _newBallButtonContainer;
        [SerializeField]
        private GameObject _newBallButtonLocker;

        [SerializeField]
        private EventButton _newBallButton;

        private bool _isAdditionalBallUsed;
        
        public override void Initialize()
        {
            base.Initialize();
            _restartButton.OnButtonPressed += OnRestartButtonPressed;
            _newBallButton.OnButtonPressed += OnNewBallButtonPressed;
            EventBus.Subscribe(this);
        }

        protected override void PreparePopup()
        {
            if (_isAdditionalBallUsed)
            {
                _newBallButtonContainer.SetActive(false);
                return;
            }

            _newBallButtonLocker.SetActive(true);
            _newBallButtonContainer.SetActive(true);
            AdsController.Instance.RewardedAdService.LoadAd(OnRewardedAdLoad);
        }

        private void OnRewardedAdLoad(bool isLoad)
        {
            _newBallButtonLocker.SetActive(false);
        }

        private void OnNewBallButtonPressed()
        {
            _isAdditionalBallUsed = true;
            AdsController.Instance.RewardedAdService.ShowAd(OnRewardedVideoShown);
        }

        private void OnRewardedVideoShown()
        {
            EventBus.RaiseEvent<IStartGameHandler>(a => a.OnContinueAfterLoseGameProcess());
        }

        private void OnRestartButtonPressed()
        {
            AdsController.Instance.InterstitialAdService.ShowAd(OnInterstitialAdShown);
        }

        private void OnInterstitialAdShown()
        {
            EventBus.RaiseEvent<IStartGameHandler>(a => a.OnRestartGameProcess());
        }

        public void OnStartGame()
        {
            _isAdditionalBallUsed = false;
        }
    }
}