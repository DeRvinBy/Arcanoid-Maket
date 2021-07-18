using DG.Tweening;
using UnityEngine;

namespace Scripts.Animations.Configs
{
    [CreateAssetMenu(fileName = "New Base Animation Config", menuName = "Animations Config/Base Animation Config")]
    public class BaseAnimationConfig : ScriptableObject
    {
        [SerializeField]
        private float _duration = 1f;

        [SerializeField]
        private Ease _easeMode = Ease.Linear;

        [SerializeField]
        private bool _isUpdate = true;

        public TweenParams TweenParams => new TweenParams().SetEase(_easeMode).SetUpdate(_isUpdate);
        public float Duration => _duration;
        public Ease EaseMode => _easeMode;
        public bool IsUpdate => _isUpdate;
    }
}