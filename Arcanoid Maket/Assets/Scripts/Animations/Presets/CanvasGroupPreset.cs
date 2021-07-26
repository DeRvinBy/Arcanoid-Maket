using System;
using Animations.Configs;
using DG.Tweening;
using UnityEngine;

namespace Animations.Presets
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

        public void ResetToStartAlpha()
        {
            _canvasGroup.alpha = _alphaConfig.StartAlpha;
        }
        
        public void ResetToEndAlpha()
        {
            _canvasGroup.alpha = _alphaConfig.EndAlpha;
        }

        public Tween GetForwardAnimation()
        {
            ResetToStartAlpha();
            var tween = _canvasGroup.DOFade(_alphaConfig.EndAlpha, _baseConfig.Duration).SetAs(_baseConfig.TweenParams);
            tween.Pause();
            return tween;
        }
        
        public Tween GetBackwardAnimation()
        {
            ResetToEndAlpha();
            var tween = _canvasGroup.DOFade(_alphaConfig.StartAlpha, _baseConfig.Duration).SetAs(_baseConfig.TweenParams);
            tween.Pause();
            return tween;
        }
    }
}