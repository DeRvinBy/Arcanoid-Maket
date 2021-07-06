using System;
using System.Collections;
using Project.Scripts.EventInterfaces.GameFieldEvents;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.GameEntities.Platform
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
            targetPosition.y = _transform.position.y;
            MoveToTargetPosition(targetPosition);
            LimitPosition();
        }
        
        private void LimitPosition()
        {
            var position = _transform.position;
            var halfSize = _model.Size / 2f;
            var positionX = Mathf.Abs(position.x) + halfSize;
            if (positionX > _worldSizeX)
            {
                if (position.x > 0)
                {
                    position.x = _worldSizeX - halfSize;
                }
                else
                {
                    position.x = - _worldSizeX + halfSize;
                }
            }

            _transform.position = position;
        }
        
        private void MoveToTargetPosition(Vector3 targetPosition)
        {
            var movement = Vector3.Lerp( _transform.position, targetPosition, _model.Speed * Time.deltaTime);
            _rigidbody.MovePosition(movement);
        }
    }
}