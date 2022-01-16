using System;
using MyLibrary.Singleton;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Serialization;

namespace Ads
{
    public class AdsController : Singleton<AdsController>, IUnityAdsInitializationListener
    {
        [Header("Main Settings")]
        [SerializeField] 
        private string _androidGameId = "4564083";
        [SerializeField] 
        private bool _testMode = true;
        
        [Header("Interstitial Ad Settings")]
        [SerializeField] 
        private string _androidInterstitialId = "Interstitial_Android";
        
        [Header("Rewarded Ad Settings")]
        [SerializeField] string _androidRewardedId = "Rewarded_Android";

        [Header("Banner Ad Settings")]
        [SerializeField] BannerPosition _bannerPosition = BannerPosition.BOTTOM_CENTER;
        [SerializeField] string _androidBannerId = "Banner_Android";

        public InterstitialAdService InterstitialAdService { get; private set; }
        public RewardedAdService RewardedAdService { get; private set; }
        public BannerAdService BannerAdService { get; private set; }

        protected override void Initialize()
        {
            InitializeAds();
        }

        private void Start()
        {
            InterstitialAdService.LoadAd();
            RewardedAdService.LoadAd(null);
        }

        private void InitializeAds()
        {
            Advertisement.Initialize(_androidGameId, _testMode, this);

            InterstitialAdService = new InterstitialAdService();
            InterstitialAdService.Initialize(_androidInterstitialId);
            
            RewardedAdService = new RewardedAdService();
            RewardedAdService.Initialize(_androidRewardedId);
            
            RewardedAdService = new RewardedAdService();
            RewardedAdService.Initialize(_androidRewardedId);

            BannerAdService = new BannerAdService();
            BannerAdService.Initialize(_androidBannerId, _bannerPosition);
        }

        public void OnInitializationComplete() { }

        public void OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
            Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
        }
    }
}