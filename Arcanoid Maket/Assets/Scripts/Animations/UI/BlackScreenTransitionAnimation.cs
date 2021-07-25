using System.Collections;
using Animations.Presets;
using DG.Tweening;
using MyLibrary.UI.Transition.Abstract;
using UnityEngine;

namespace Animations.UI
{
    public class BlackScreenTransitionAnimation : AbstractTransitionAnimation
    {
        [SerializeField]
        private CanvasGroupPreset _imageCanvasAnimation;

        public override IEnumerator PlayForwardAnimation()
        {
            var tween = _imageCanvasAnimation.GetForwardAnimation();
            tween.Play();
            yield return tween.WaitForCompletion();
        }
        
        public override IEnumerator PlayBackwardAnimation()
        {
            var tween = _imageCanvasAnimation.GetBackwardAnimation();
            tween.Play();
            yield return tween.WaitForCompletion();
        }
    }
}