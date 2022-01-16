using System;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Ads
{
    public class InterstitialAdService : IUnityAdsLoadListener, IUnityAdsShowListener
    {
        private Action _onShowComplete;
        private string _adUnitId;

        public void Initialize(string adUnitId)
        {
            _adUnitId = adUnitId;
        }
    
        public void LoadAd()
        {
            Advertisement.Load(_adUnitId, this);
        }
    
        public void ShowAd(Action onComplete)
        {
            _onShowComplete = onComplete;
            Advertisement.Show(_adUnitId, this);
        }
    
        public void OnUnityAdsAdLoaded(string adUnitId)
        {
        
        }

        public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
        {
            Debug.Log($"Error loading Ad Unit: {adUnitId} - {error.ToString()} - {message}");
        }

        public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
        {
            _onShowComplete?.Invoke();
            _onShowComplete = null;
            Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        }

        public void OnUnityAdsShowStart(string adUnitId) { }
        public void OnUnityAdsShowClick(string adUnitId) { }

        public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
        {
            _onShowComplete?.Invoke();
            _onShowComplete = null;
        }
    }
}