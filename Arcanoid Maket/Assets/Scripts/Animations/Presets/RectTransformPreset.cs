using System;
using Animations.Configs;
using DG.Tweening;
using UnityEngine;

namespace Animations.Presets
{
    [Serializable]
    public class RectTransformPreset
    {
        [SerializeField]
        private BaseAnimationConfig _baseConfig;

        [SerializeField]
        private RectTransform _rectTransform;
        
        [SerializeField]
        private RectTransformAnimationConfig _rectTransformConfig;
        
        public Tween GetForwardAnimation()
        {
            _rectTransform.anchoredPosition = _rectTransformConfig.StartPosition;
            var tween = _rectTransform.DOAnchorPos(_rectTransformConfig.EndPosition, _baseConfig.Duration).SetAs(_baseConfig.TweenParams);
            tween.Pause();
            return tween;
        }
        
        public Tween GetBackwardAnimation()
        {
            _rectTransform.anchoredPosition = _rectTransformConfig.EndPosition;
            var tween = _rectTransform.DOAnchorPos(_rectTransformConfig.StartPosition, _baseConfig.Duration).SetAs(_baseConfig.TweenParams);
            tween.Pause();
            return tween;
        }
    }
}