using Animations.Configs;
using DG.Tweening;
using MyLibrary.UI.Button.Abstract;
using UnityEngine;
using UnityEngine.UI;

namespace Animations.UI
{
    public class ButtonAnimation : AbstractButtonAnimation
    {
        [SerializeField]
        private BaseAnimationConfig _baseConfig;
        
        [SerializeField]
        private ScaleAnimationConfig _scaleConfig;
        
        [SerializeField]
        private BrightnessAnimationConfig _brightnessConfig;

        [SerializeField]
        private RectTransform _rectTransform;

        [SerializeField]
        private Image _image;
        
        private Sequence _sequence;

        public override void SetupAnimation()
        {
            CreateAnimation();
        }
        
        private void CreateAnimation()
        {
            var localScale = _rectTransform.localScale;
            var halfDuration = _baseConfig.Duration / 2f;
            var startColor = _brightnessConfig.GetStartColor(_image.color);
            var targetColor = _brightnessConfig.GetTargetColor(_image.color);
            var scaleParams = new TweenParams().SetEase(_baseConfig.EaseMode).SetUpdate(_baseConfig.IsUpdate);
            var colorParams = new TweenParams().SetUpdate(_baseConfig.IsUpdate);

            _sequence = DOTween.Sequence();
            _sequence.Pause();
            _sequence.SetAutoKill(false);
            
            var scale = localScale * _scaleConfig.TargetScale;
            _sequence.Append(_rectTransform.DOScale(scale , halfDuration).SetAs(scaleParams));
            _sequence.Join(_image.DOColor(targetColor, halfDuration)).SetAs(colorParams);
            scale = localScale * _scaleConfig.StartScale;
            _sequence.Append(_rectTransform.DOScale(scale, halfDuration).SetAs(scaleParams));
            _sequence.Join(_image.DOColor(startColor, halfDuration)).SetAs(colorParams);
            
            _sequence.OnComplete(() => _sequence.Rewind());
        }
        
        public override void PlayAnimation(TweenCallback callback)
        {
            if (!_sequence.IsPlaying())
            {
                _sequence.Play().onComplete += callback;
            }
        }

        private void OnDestroy()
        {
            _sequence.Kill();
        }
    }
}