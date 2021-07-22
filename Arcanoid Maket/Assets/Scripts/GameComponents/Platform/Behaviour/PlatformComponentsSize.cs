using UnityEngine;

namespace GameComponents.Platform.Behaviour
{
    public class PlatformComponentsSize : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        private Transform _transform;
        
        private void Awake()
        {
            _transform = transform;
        }

        public void UpdateComponentsSize(float value)
        {
            var scale = _transform.localScale;
            scale.x = value;
            _transform.localScale = scale;

            var spriteSize = _spriteRenderer.size;
            spriteSize.x = value;
            _spriteRenderer.size = spriteSize;
        }
    }
}