using DG.Tweening;
using Project.Scripts.Animations.Configs;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.Animations.UI
{
    public class ButtonAnimation : MonoBehaviour
    {
        [SerializeField]
        private BaseAnimationConfig _baseConfig;
        
        [SerializeField]
        private ScaleAnimationConfig _scaleConfig;
        
        [SerializeField]
        private ColorAnimationConfig _colorConfig;

        [SerializeField]
        private RectTransform _rectTransform;

        [SerializeField]
        private Image _image;
        
        private Sequence _sequence;

        public void Initialize()
        {
            _image.color = _colorConfig.StartColor;
            CreateAnimation();
        }
        
        private void CreateAnimation()
        {
            var localScale = _rectTransform.localScale;
            var halfDuration = _baseConfig.Duration / 2f;
            var scaleParams = new TweenParams().SetEase(_baseConfig.EaseMode).SetUpdate(_baseConfig.IsUpdate);
            var colorParams = new TweenParams().SetUpdate(_baseConfig.IsUpdate);

            _sequence = DOTween.Sequence();
            _sequence.Pause();
            _sequence.SetAutoKill(false);
            
            var scale = localScale * _scaleConfig.TargetScale;
            _sequence.Append(_rectTransform.DOScale(scale , halfDuration).SetAs(scaleParams));
            _sequence.Join(_image.DOColor(_colorConfig.TargetColor, halfDuration)).SetAs(colorParams);
            scale = localScale * _scaleConfig.StartScale;
            _sequence.Append(_rectTransform.DOScale(scale, halfDuration).SetAs(scaleParams));
            _sequence.Join(_image.DOColor(_colorConfig.StartColor, halfDuration)).SetAs(colorParams);
            
            _sequence.OnComplete(() => _sequence.Rewind());
        }
        
        public void PlayAnimation(TweenCallback callback)
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