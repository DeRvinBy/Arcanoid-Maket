using System;
using System.Collections;
using Project.Scripts.EventInterfaces.Input;
using Project.Scripts.GameEntities.Platform.Data;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.GameEntities.Platform
{
    public class PlatformBehaviour : MonoBehaviour, IMoveToTargetHandler
    {
        private const float ThresholdDeltaChanged = 0.05f;
        
        [SerializeField]
        private Camera _sceneCamera;
        
        [SerializeField]
        private Rigidbody2D _rigidbody;

        private PlatformProperties _properties;
        private Transform _transform;
        private Vector3 _initialPosition;
        private float _worldSizeX;
        private bool _isMove;

        private Vector3 _targetPosition;

        public void Initialize(PlatformProperties platformProperties)
        {
            _properties = platformProperties;
            _transform = transform;
            _initialPosition = _transform.position;
            _targetPosition = _initialPosition;
            _worldSizeX = _sceneCamera.orthographicSize * _sceneCamera.aspect;
            
            EventBus.Subscribe(this);
        }

        public void SetupPlatform()
        {
            var scale = _transform.localScale;
            scale.x = _properties.Size;
            _transform.localScale = scale;

            _isMove = true;
        }

        public void ResetPlatform(Action callback)
        {
            StartCoroutine(ResetPlatformPosition(callback));
        }
        
        public void DisablePlatform()
        {
            StartCoroutine(ResetPlatformPosition(() => _isMove = false));
        }

        private IEnumerator ResetPlatformPosition(Action callback)
        {
            _isMove = false;
            while (Mathf.Abs(_transform.position.x - _initialPosition.x) > ThresholdDeltaChanged)
            {
                MoveToTargetPosition(_initialPosition);
                yield return new WaitForEndOfFrame();
            }

            _isMove = true;
            callback?.Invoke();
        }

        public void OnMoveToMouse(Vector3 position)
        {
            if (!_isMove) return;

            var targetPosition = _sceneCamera.ScreenToWorldPoint(position);
            targetPosition.y = _transform.position.y;
            MoveToTargetPosition(targetPosition);
            LimitPosition();
        }

        private void MoveToTargetPosition(Vector2 targetPosition)
        {
            Vector2 currentPosition = transform.position;
            var distance = (targetPosition - currentPosition).x;
            var direction = Mathf.Clamp(distance, -_properties.Speed, _properties.Speed);
            _targetPosition.x = currentPosition.x + direction * Time.fixedDeltaTime;
            
            _rigidbody.MovePosition(_targetPosition);
        }

        private void LimitPosition()
        {
            var position = _transform.position;
            var halfSize = _properties.Size / 2f;
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
    }
}