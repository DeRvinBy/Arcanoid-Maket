using UnityEngine;

namespace Scripts.Animations.Configs
{
    [CreateAssetMenu(fileName = "New Alpha Animation Config", menuName = "Animations Config/Alpha Animation Config")]
    public class AlphaAnimationConfig : ScriptableObject
    {
        [SerializeField]
        private float _startAlpha;

        [SerializeField]
        private float _endAlpha;

        public float EndAlpha => _endAlpha;
        public float StartAlpha => _startAlpha;
    }
}