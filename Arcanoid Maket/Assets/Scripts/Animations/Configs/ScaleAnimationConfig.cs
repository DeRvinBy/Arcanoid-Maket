using UnityEngine;

namespace Animations.Configs
{
    [CreateAssetMenu(fileName = "New Scale Animation Config", menuName = "Animations Config/Scale Animation Config")]
    public class ScaleAnimationConfig : ScriptableObject
    {
        [SerializeField] 
        private float _startScale = 1f;
        
        [SerializeField] 
        private float _targetScale = 0.8f;

        public float StartScale => _startScale;

        public float TargetScale => _targetScale;
    }
}