using System;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Ads
{
    public class RewardedAdService : IUnityAdsLoadListener, IUnityAdsShowListener
    {
        public bool IsAdLoad { get; private set; }
        
        private Action<bool> _onLoadComplete;
        private Action _onShowComplete;
        private string _adUnitId;

        public void Initialize(string adUnitId)
        {
            _adUnitId = adUnitId;
        }
        
        public void LoadAd(Action<bool> onLoadComplete)
        {
            if (IsAdLoad)
            {
                onLoadComplete?.Invoke(true);
                IsAdLoad = false;
                return;
            }

            Advertisement.Load(_adUnitId, this);
            _onLoadComplete = onLoadComplete;
        }
        
        public void OnUnityAdsAdLoaded(string adUnitId)
        {
            if (adUnitId.Equals(_adUnitId))
            {
                _onLoadComplete?.Invoke(true);
                _onLoadComplete = null;
                IsAdLoad = true;
            }
        }

        public void ShowAd(Action onComplete)
        {
            IsAdLoad = false;
            _onShowComplete = onComplete;
            Advertisement.Show(_adUnitId, this);
        }
        
        public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
        {
            if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
            {
                _onShowComplete?.Invoke();
                _onShowComplete = null;
                LoadAd(null);
            }
        }

        public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
        {
            _onLoadComplete?.Invoke(false);
            _onLoadComplete = null;
            Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
        }

        public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
        {
            Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        }

        public void OnUnityAdsShowStart(string adUnitId) { }
        public void OnUnityAdsShowClick(string adUnitId) { }
    }
}