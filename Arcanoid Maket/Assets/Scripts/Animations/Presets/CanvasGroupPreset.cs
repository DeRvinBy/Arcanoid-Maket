using System;
using DG.Tweening;
using Scripts.Animations.Configs;
using UnityEngine;

namespace Scripts.Animations.Presets
{
    [Serializable]
    public class CanvasGroupPreset
    {
        [SerializeField]
        private BaseAnimationConfig _baseConfig;

        [SerializeField]
        private CanvasGroup _canvasGroup;

        [SerializeField]
        private AlphaAnimationConfig _alphaConfig;

        public Tween GetForwardAnimation()
        {
            _canvasGroup.alpha = _alphaConfig.StartAlpha;
            var tween = _canvasGroup.DOFade(_alphaConfig.EndAlpha, _baseConfig.Duration).SetAs(_baseConfig.TweenParams);
            tween.Pause();
            return tween;
        }
        
        public Tween GetBackwardAnimation()
        {
            _canvasGroup.alpha = _alphaConfig.EndAlpha;
            var tween = _canvasGroup.DOFade(_alphaConfig.StartAlpha, _baseConfig.Duration).SetAs(_baseConfig.TweenParams);
            tween.Pause();
            return tween;
        }
    }
}