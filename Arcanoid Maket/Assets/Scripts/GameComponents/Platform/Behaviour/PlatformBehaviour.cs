using System;
using System.Collections;
using Scripts.EventInterfaces.Input;
using Scripts.GameComponents.Platform.Data;
using Scripts.Utils.EventSystem;
using UnityEngine;

namespace Scripts.GameComponents.Platform.Behaviour
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

        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(this);
        }

        public void Initialize(PlatformProperties platformProperties)
        {
            _properties = platformProperties;
            _transform = transform;
            _initialPosition = _transform.position;
            _worldSizeX = _sceneCamera.orthographicSize * _sceneCamera.aspect;
        }

        public void SetupPlatform()
        {
            var scale = _transform.localScale;
            scale.x = _properties.Size;
            _transform.localScale = scale;
            _transform.position = _initialPosition;

            _isMove = true;
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
            var halfSize = _properties.Size / 2f;
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

            return targetPosition;
        }
        
        private void MoveToTargetPosition(Vector2 targetPosition)
        {
            if (Mathf.Abs(_transform.position.x - targetPosition.x) > ThresholdDeltaChanged)
            {
                Vector2 currentPosition = transform.position;
                var distanceX = (targetPosition - currentPosition).normalized.x * _properties.Speed;
                targetPosition.x = currentPosition.x + distanceX * Time.fixedDeltaTime;
                    
                _rigidbody.MovePosition(targetPosition);
            }
        }
    }
}