using System;
using System.Collections;
using Project.Scripts.MVC.GameField.EventInterfaces;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.MVC.Platform
{
    public class PlatformView : MonoBehaviour, IBallOutBorderEvent
    {
        [SerializeField]
        private Camera _sceneCamera;
        
        [SerializeField]
        private Rigidbody2D _rigidbody;
        
        private PlatformModel _model;
        private Transform _transform;
        private Vector3 _initialPosition;
        private float _worldSizeX;
        private bool _isMove;
        
        public void Initialize(PlatformModel model)
        {
            _model = model;
            _transform = transform;
            _initialPosition = _transform.position;
            _worldSizeX = _sceneCamera.orthographicSize * _sceneCamera.aspect;
            
            EventBus.Subscribe(this);
        }

        public void StartView()
        {
            SetPlatformScale();
            _isMove = true;
        }

        private void SetPlatformScale()
        {
            var scale = _transform.localScale;
            scale.x *= _model.Size;
            _transform.localScale = scale;
        }
        
        public void OnBallOut()
        {
            _isMove = false;
        }

        public IEnumerator ResetPlatformPosition()
        {
            while (Math.Abs(_transform.position.x - _initialPosition.x) > 0.01f)
            {
                MoveToTargetPosition(_initialPosition);
                yield return new WaitForEndOfFrame();
            }

            _isMove = true;
        }
        
        public void UpdatePlatformPosition(Vector2 mousePosition)
        {
            if (!_isMove) return;
            
            var targetPosition = _sceneCamera.ScreenToWorldPoint(mousePosition);
            targetPosition = LimitTargetPosition(targetPosition);
            MoveToTargetPosition(targetPosition);
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
        
        private void MoveToTargetPosition(Vector3 targetPosition)
        {
            var movement = Vector3.Lerp( _transform.position, targetPosition, _model.Speed * Time.deltaTime);
            _rigidbody.MovePosition(movement);
        }
    }
}