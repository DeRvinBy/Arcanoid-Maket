using System;
using DG.Tweening;
using UnityEngine;

namespace Project.Scripts.Animations
{
    public class ValueAnimation
    {
        private float _duration;
        private Ease _easeMode;

        public ValueAnimation(float duration, Ease easeMode)
        {
            _duration = duration;
            _easeMode = easeMode;
        }
        
        public void PlayAnimation(float from, float to, Action<float> updateAction)
        {
            var tween = DOVirtual.Float(from, to, _duration, (v) => updateAction(v));
            tween.SetEase(_easeMode);
            tween.OnComplete(() => tween.Kill());
        }
    }
}