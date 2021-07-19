using UnityEngine;

namespace Animations.Configs
{
    [CreateAssetMenu(fileName = "New Color Animation Config", menuName = "Animations Config/Color Animation Config")]
    public class ColorAnimationConfig : ScriptableObject
    {
        [SerializeField]
        private Color _startColor = Color.white;
        
        [SerializeField]
        private Color _targetColor = Color.black;

        public Color StartColor => _startColor;

        public Color TargetColor => _targetColor;
    }
}