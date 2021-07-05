using System.Collections;
using Project.Scripts.GameSettings.GamePlatformSettings;
using Project.Scripts.MVC.Ball;
using Project.Scripts.MVC.Ball.Creation;
using UnityEngine;

namespace Project.Scripts.MVC.Platform
{
    public class PlatformView : MonoBehaviour
    {
        [SerializeField]
        private Camera _sceneCamera;
        
        [SerializeField]
        private Rigidbody2D _rigidbody;
        
        private PlatformModel _model;
        private Transform _transform;

        public void Initialize(PlatformModel model)
        {
            _model = model;
            _transform = transform;
        }

        public void UpdatePlatformPosition(Vector2 mousePosition)
        {
            var targetPosition = _sceneCamera.ScreenToWorldPoint(mousePosition);
            var currentPosition = _transform.position;
            targetPosition.y = currentPosition.y;
            var movement = Vector3.Lerp( currentPosition, targetPosition, _model.Speed * Time.deltaTime);
            _rigidbody.MovePosition(movement);
        }
        
        public void StartView()
        {
            SetupScale();
        }

        private void SetupScale()
        {
            var scale = _transform.localScale;
            scale.x *= _model.Size;
            _transform.localScale = scale;
        }
    }
}