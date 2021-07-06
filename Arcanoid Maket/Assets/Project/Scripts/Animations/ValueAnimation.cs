using System;
using DG.Tweening;
using UnityEngine;

namespace Project.Scripts.Animations
{
    public class ValueAnimation : MonoBehaviour
    {
        [SerializeField]
        private float _animationDuration = 1f;

        [SerializeField]
        private Ease _easeMode = Ease.Linear;
        
        public void PlayAnimation(float from, float to, Action<float> updateAction)
        {
            var tween = DOVirtual.Float(from, to, _animationDuration, (v) => updateAction(v));
            tween.SetEase(_easeMode);
            tween.OnComplete(() => tween.Kill());
        }
    }
}