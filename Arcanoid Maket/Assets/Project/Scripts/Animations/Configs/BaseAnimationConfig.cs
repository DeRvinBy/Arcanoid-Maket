using DG.Tweening;
using UnityEngine;

namespace Project.Scripts.Animations.Configs
{
    [CreateAssetMenu(fileName = "New Base Animation Config", menuName = "Animations Config/Base Animation Config")]
    public class BaseAnimationConfig : ScriptableObject
    {
        [SerializeField]
        private float _duration = 1f;

        [SerializeField]
        private Ease _easeMode = Ease.Linear;

        public float Duration => _duration;
        public Ease EaseMode => _easeMode;
    }
}