using UnityEngine;
using UnityEngine.Advertisements;

namespace Ads
{
    public class BannerAdService
    {
        private string _adUnitId;
        private BannerPosition _bannerPosition;

        public void Initialize(string adUnitId, BannerPosition bannerPosition)
        {
            _adUnitId = adUnitId;
            _bannerPosition = bannerPosition;
            
            Advertisement.Banner.SetPosition(_bannerPosition);
        }
        
        public void LoadBannerAd()
        {
            var options = new BannerLoadOptions
            {
                loadCallback = OnBannerLoaded,
                errorCallback = OnBannerError
            };
            
            Advertisement.Banner.Load(_adUnitId, options);
        }
        
        private void OnBannerLoaded() { }
        
        private void OnBannerError(string message)
        {
            Debug.Log($"Banner Error: {message}");
        }
        
        public void ShowBannerAd()
        {
            var options = new BannerOptions
            {
                clickCallback = OnBannerClicked,
                hideCallback = OnBannerHidden,
                showCallback = OnBannerShown
            };

            Advertisement.Banner.Show(_adUnitId, options);
        }

        public void HideBannerAd()
        {
            Advertisement.Banner.Hide();
        }

        void OnBannerClicked() { }
        void OnBannerShown() { }
        void OnBannerHidden() { }
    }
}