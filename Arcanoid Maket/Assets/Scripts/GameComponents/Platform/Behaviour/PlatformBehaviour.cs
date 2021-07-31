using System;
using System.Collections;
using EventInterfaces.Input;
using MyLibrary.EventSystem;
using UnityEngine;

namespace GameComponents.Platform.Behaviour
{
    public class PlatformBehaviour : MonoBehaviour, IMoveToTargetHandler
    {
        private const float ThresholdDeltaChanged = 0.1f;
        
        [SerializeField]
        private Camera _sceneCamera;
        
        [SerializeField]
        private Rigidbody2D _rigidbody;

        [SerializeField]
        private PlatformComponentsSize _platformComponentsSize;
        
        private Transform _transform;
        private Vector3 _initialPosition;
        private float _currentSpeed;
        private float _currentSize;
        private float _worldBoundX;
        private float _worldSizeX;
        private bool _isMove;

        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(this);
        }

        public void Initialize()
        {
            _transform = transform;
            _initialPosition = _transform.position;
            _worldBoundX = _sceneCamera.orthographicSize * _sceneCamera.aspect;
            _worldSizeX = _worldBoundX * 2;
        }

        public void SetupPlatform(float speed, float size)
        {
            UpdatePlatformSpeed(speed);
            UpdatePlatformSize(size);
            _transform.position = _initialPosition;
            _isMove = true;
            StopAllCoroutines();
        }

        public void UpdatePlatformSize(float value)
        {
            _currentSize = _worldSizeX * value;
            _platformComponentsSize.UpdateComponentsSize(_currentSize);
        }
        
        public void UpdatePlatformSpeed(float value)
        {
            _currentSpeed = value;
        }

        public void ResetPlatformWithCallback(Action callback)
        {
            StartCoroutine(ResetPlatformPosition(callback));
        }
        
        public void ResetPlatform()
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
            targetPosition = LimitTargetPosition(targetPosition);
            MoveToTargetPosition(targetPosition);
        }

        private Vector3 LimitTargetPosition(Vector3 targetPosition)
        {
            targetPosition.y = _transform.position.y;
            var halfSize = _currentSize / 2f;
            var positionX = Mathf.Abs(targetPosition.x) + halfSize;

            if (positionX > _worldBoundX)
            {
                if (targetPosition.x > 0)
                {
                    targetPosition.x = _worldBoundX - halfSize;
                }
                else
                {
                    targetPosition.x = - _worldBoundX + halfSize;
                }
            }

            return targetPosition;
        }
        
        private void MoveToTargetPosition(Vector2 targetPosition)
        {
            if (Mathf.Abs(_transform.position.x - targetPosition.x) > ThresholdDeltaChanged)
            {
                Vector2 currentPosition = transform.position;
                var distanceX = (targetPosition - currentPosition).normalized.x * _currentSpeed;
                targetPosition.x = currentPosition.x + distanceX * Time.fixedDeltaTime;
                    
                _rigidbody.MovePosition(targetPosition);
            }
        }
    }
}