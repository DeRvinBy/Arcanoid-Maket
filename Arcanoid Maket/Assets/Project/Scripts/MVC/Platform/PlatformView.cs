using UnityEngine;

namespace Project.Scripts.MVC.Platform
{
    public class PlatformView : MonoBehaviour
    {
        private const float BorderOffset = 0.1f;
        
        [SerializeField]
        private Camera _sceneCamera = null;
        
        [SerializeField]
        private Rigidbody2D _rigidbody = null;

        private PlatformModel _model;
        private Transform _transform;

        public void Initialize(PlatformModel model)
        {
            _model = model;
            _transform = transform;
        }

        public void StartView()
        {
            var scale = _transform.localScale;
            scale.x *= _model.Size;
            _transform.localScale = scale;
        }
        
        public void UpdatePlatformPosition(Vector2 mousePosition)
        {
            var targetPosition = _sceneCamera.ScreenToWorldPoint(mousePosition);
            targetPosition.y = _transform.position.y;
            var movement = Vector3.Lerp( _transform.position, targetPosition, _model.Speed * Time.deltaTime);
            _rigidbody.MovePosition(movement);
        }
    }
}