﻿using System;
using DG.Tweening;
using UnityEngine;

namespace Project.Scripts.Animations
{
    public class ValueAnimation
    {
        private float _duration;
        private Ease _tweenParams;

        private Tween _tween;
        
        public ValueAnimation(Ease tweenParams, float duration)
        {
            _tweenParams = tweenParams;
            _duration = duration;
        }
        
        public void PlayAnimation(float from, float to, Action<float> updateAction)
        {
            _tween = DOVirtual.Float(from, to, _duration, (v) => updateAction(v)).SetEase(_tweenParams);
        }

        public void KillAnimation()
        {
            _tween?.Kill();
        }
    }
}