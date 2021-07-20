using System.Collections;
using Animations.Presets;
using DG.Tweening;
using MyLibrary.UI.Popup.Abstract;
using UnityEngine;

namespace Animations.UI
{
    public class MenuPopupAnimation : AbstractPopupAnimation
    {
        [SerializeField]
        private RectTransformPreset _selectorTransformAnimation;
        
        [SerializeField]
        private RectTransformPreset _gameTextTransformAnimation;
        
        [SerializeField]
        private CanvasGroupPreset _gameTextCanvasAnimation;
        
        [SerializeField]
        private CanvasGroupPreset _playButtonCanvasAnimation;

        private Sequence _sequence;
        
        public override void SetupAnimation()
        {
            _sequence = DOTween.Sequence();
            _sequence.Pause();
            _sequence.SetAutoKill(false);
            _sequence.Append(_selectorTransformAnimation.GetForwardAnimation());
            _sequence.Append(_gameTextTransformAnimation.GetForwardAnimation());
            _sequence.Join(_gameTextCanvasAnimation.GetForwardAnimation());
            _sequence.Append(_playButtonCanvasAnimation.GetForwardAnimation());
        }

        public override IEnumerator PlayHideAnimation()
        {
            yield return null;
        }

        public override IEnumerator PlayShowAnimation()
        {
            if (!_sequence.IsPlaying())
            {
                _sequence.Play();
                yield return _sequence.WaitForCompletion();
            }
        }
    }
}