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

        private float _worldSizeX;
        
        public void Initialize(PlatformModel model)
        {
            _model = model;
            _transform = transform;
            _worldSizeX = _sceneCamera.orthographicSize * _sceneCamera.aspect;
        }

        public void UpdatePlatformPosition(Vector2 mousePosition)
        {
            var targetPosition = _sceneCamera.ScreenToWorldPoint(mousePosition);
            targetPosition = LimitTargetPosition(targetPosition);
            var movement = Vector3.Lerp( _transform.position, targetPosition, _model.Speed * Time.deltaTime);
            _rigidbody.MovePosition(movement);
        }

        private Vector3 LimitTargetPosition(Vector3 targetPosition)
        {
            var halfSize = _model.Size / 2f;
            var positionX = Mathf.Abs(targetPosition.x) + halfSize;
            if (positionX > _worldSizeX)
            {
                if (targetPosition.x > 0)
                {
                    targetPosition.x = _worldSizeX - halfSize;
                }
                else
                {
                    targetPosition.x = - _worldSizeX + halfSize;
                }
            }
            targetPosition.y = _transform.position.y;

            return targetPosition;
        }
        
        public void StartView()
        {
            SetPlatformScale();
        }

        private void SetPlatformScale()
        {
            var scale = _transform.localScale;
            scale.x *= _model.Size;
            _transform.localScale = scale;
        }
    }
}