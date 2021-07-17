using UnityEngine;

namespace Project.Scripts.Animations.Configs
{
    [CreateAssetMenu(fileName = "New RectTransform Animation Config", menuName = "Animations Config/RectTransform Animation Config")]
    public class RectTransformAnimationConfig : ScriptableObject
    {
        [SerializeField]
        private Vector2 _startPosition;

        [SerializeField]
        private Vector2 _endPosition;

        public Vector2 EndPosition => _endPosition;
        public Vector2 StartPosition => _startPosition;
    }
}