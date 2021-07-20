using System.Collections;
using Animations.Configs;
using DG.Tweening;
using MyLibrary.UI.Popup.Abstract;
using UnityEngine;

namespace Animations.UI
{
    public class PopupAnimation : AbstractPopupAnimation
    {
        [Header("Animation parameters")]
        [SerializeField]
        private BaseAnimationConfig _baseConfig;

        [Header("Rect Transform parameters")]
        [SerializeField]
        private RectTransform _rectTransform;

        [SerializeField]
        private Vector2 _hidePosition;

        [SerializeField]
        private Vector2 _showPosition;

        [Header("Canvas Group parameters")]
        [SerializeField]
        private CanvasGroup _canvas;
        
        [SerializeField]
        private float _hideAlpha;

        [SerializeField]
        private float _showAlpha;

        private Tween _hideTransformTween;
        private Tween _showTransformTween;
        private Tween _hideCanvasTween;
        private Tween _showCanvasTween;
        
        [ContextMenu("Set hide parameters by current parameters")]
        public void SetHideParameters()
        {
            _hidePosition = _rectTransform.anchoredPosition;
            _hideAlpha = _canvas.alpha;
        }
        
        [ContextMenu("Set show parameters by current parameters")]
        public void SetShowParameters()
        {
            _showPosition = _rectTransform.anchoredPosition;
            _showAlpha = _canvas.alpha;
        }

        public override void SetupAnimation()
        {
            var tweenParams = new TweenParams().SetEase(_baseConfig.EaseMode).SetUpdate(_baseConfig.IsUpdate).SetAutoKill(false);
            _hideTransformTween = _rectTransform.DOAnchorPos(_hidePosition, _baseConfig.Duration).SetAs(tweenParams);
            _hideTransformTween.Pause();
            _showTransformTween = _rectTransform.DOAnchorPos(_showPosition, _baseConfig.Duration).SetAs(tweenParams);
            _showTransformTween.Pause();
            _hideCanvasTween = _canvas.DOFade(_hideAlpha, _baseConfig.Duration).SetAs(tweenParams);
            _hideCanvasTween.Pause();
            _showCanvasTween = _canvas.DOFade(_showAlpha, _baseConfig.Duration).SetAs(tweenParams);
            _showCanvasTween.Pause();
        }

        public override IEnumerator PlayHideAnimation()
        {
            _rectTransform.anchoredPosition = _showPosition;
            _canvas.alpha = _showAlpha;
            _hideTransformTween.Restart();
            _hideCanvasTween.Restart();
            yield return _hideTransformTween.WaitForCompletion();
            yield return _hideCanvasTween.WaitForCompletion();
        }
        
        public override IEnumerator PlayShowAnimation()
        {
            _rectTransform.anchoredPosition = _hidePosition;
            _canvas.alpha = _hideAlpha;
            _showTransformTween.Restart();
            _showCanvasTween.Restart();
            yield return _showTransformTween.WaitForCompletion();
            yield return _showCanvasTween.WaitForCompletion();
        }
    }
}