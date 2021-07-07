using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Project.Scripts.Animations.UI
{
    public class PopupAnimation : MonoBehaviour
    {
        [Header("Animation parameters")]
        [SerializeField]
        private float _animationDuration;

        [SerializeField]
        private Ease _easeMode = Ease.Linear;

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
        
        [ContextMenu("Set hide parameters by current parameters")]
        public void SetShowParameters()
        {
            _showPosition = _rectTransform.anchoredPosition;
            _showAlpha = _canvas.alpha;
        }

        public void SetupAnimation()
        {
            var tweenParams = new TweenParams().SetEase(_easeMode).SetLoops(-1).SetAutoKill(false);
            _hideTransformTween = _rectTransform.DOAnchorPos(_hidePosition, _animationDuration).SetAs(tweenParams);
            _hideTransformTween.Pause();
            _showTransformTween = _rectTransform.DOAnchorPos(_showPosition, _animationDuration).SetAs(tweenParams);
            _showTransformTween.Pause();
            _hideCanvasTween = _canvas.DOFade(_hideAlpha, _animationDuration).SetAs(tweenParams);
            _hideCanvasTween.Pause();
            _showCanvasTween = _canvas.DOFade(_showAlpha, _animationDuration).SetAs(tweenParams);
            _showCanvasTween.Pause();
        }

        public IEnumerator PlayHideAnimation()
        {
            _hideTransformTween.Play();
            _hideCanvasTween.Play();
            yield return _hideTransformTween.WaitForCompletion();
            yield return _hideCanvasTween.WaitForCompletion();
        }
        
        public IEnumerator PlayShowAnimation()
        {
            _showTransformTween.Play();
            _showCanvasTween.Play();
            yield return _showTransformTween.WaitForCompletion();
            yield return _showCanvasTween.WaitForCompletion();
        }
    }
}