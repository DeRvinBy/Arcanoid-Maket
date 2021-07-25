using System;
using DG.Tweening;

namespace Animations
{
    public class ValueAnimation
    {
        private float _duration;
        private Ease _tweenParams;

        private bool _isPlaying;

        public ValueAnimation(Ease tweenParams, float duration)
        {
            _tweenParams = tweenParams;
            _duration = duration;
        }
        
        public void PlayAnimation(float from, float to, Action<float> updateAction)
        {
            _isPlaying = true;
            DOVirtual.Float(from, to, _duration, (v) =>
            {
                if (_isPlaying)
                {
                    updateAction(v);
                }
            }).SetEase(_tweenParams);
        }
        
        public Tween GetAnimation(float from, float to, Action<float> updateAction)
        {
            var tween = DOVirtual.Float(from, to, _duration, (v) => updateAction(v)).SetEase(_tweenParams);
            tween.Pause();
            return tween;
        }

        public void StopAnimation()
        {
            _isPlaying = false;
        }
    }
}