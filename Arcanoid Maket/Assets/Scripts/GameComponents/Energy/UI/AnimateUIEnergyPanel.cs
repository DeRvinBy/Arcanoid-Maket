using Animations;
using Animations.Configs;
using DG.Tweening;
using MyLibrary.EnergySystem;
using MyLibrary.EnergySystem.Interfaces;
using MyLibrary.EventSystem;
using MyLibrary.Extensions;
using TMPro;
using UnityEngine;

namespace GameComponents.Energy.UI
{
    public class AnimateUIEnergyPanel : MonoBehaviour, IEnergyUpdatedHandler
    {
        [SerializeField]
        private BaseAnimationConfig _baseConfig;
        
        [SerializeField]
        private TMP_Text _energyInfoText;

        [SerializeField]
        private string _energyInfoFormat = "{0}/{1}";
        
        [SerializeField]
        private TMP_Text _timerToNextEnergyText;
        
        [SerializeField]
        private string _timerToNextEnergyFormat = "{0:d2}:{1:d2}";

        private ValueAnimation _valueAnimation;
        private bool _isUpdateTimer;
        private bool _isAnimationComplete;
        private int _currentEnergy;
        private int _maxEnergy;

        private void Awake()
        {
            _valueAnimation = new ValueAnimation(_baseConfig.EaseMode, _baseConfig.Duration);
        }

        private void OnEnable()
        {
            EventBus.Subscribe(this);
            _isAnimationComplete = true;
            OnEnergyUpdated();
            _isAnimationComplete = false;
            _timerToNextEnergyText.SetActive(false);
        }

        private void OnDisable()
        {
            _isAnimationComplete = false;
            _valueAnimation.StopAnimation();
            EventBus.Unsubscribe(this);
        }
        
        private void Update()
        {
            if (_isUpdateTimer)
            {
                var interval = EnergyManager.Instance.GetCurrentRestoreInterval();
                var intervalText = string.Format(_timerToNextEnergyFormat, interval.Minutes, interval.Seconds);
                _timerToNextEnergyText.text = intervalText;
            }
        }
        
        public void OnEnergyUpdated()
        {
            if (!_isAnimationComplete) return;
            
            var info = EnergyManager.Instance.GetEnergyInfo();
            _currentEnergy = info.CurrentEnergy;
            _maxEnergy = info.MaxEnergy;
            SetEnergyText(_currentEnergy);
            _isUpdateTimer = !info.IsFullEnergy;
            _timerToNextEnergyText.SetActive(_isUpdateTimer);
        }

        private void SetEnergyText(float value)
        {
            var energyText = string.Format(_energyInfoFormat, (int)value, _maxEnergy);
            _energyInfoText.text = energyText;
        }

        public void PlayAnimation()
        {
            var info = EnergyManager.Instance.GetEnergyInfo();
            var tween = _valueAnimation.GetAnimation(_currentEnergy, info.CurrentEnergy, SetEnergyText);
            tween.onComplete += () => UpdateEnergyPanel(info.IsFullEnergy);
            tween.Play();
        }

        private void UpdateEnergyPanel(bool isFullEnergy)
        {
            _isUpdateTimer = !isFullEnergy;
            _timerToNextEnergyText.SetActive(_isUpdateTimer);
            _isAnimationComplete = true;
        }
    }
}