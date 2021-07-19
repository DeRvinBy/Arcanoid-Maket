using EventInterfaces.BallEvents;
using GameEntities.Ball;
using GameSettings.GameFieldSettings;
using Library.EventSystem;
using UnityEngine;

namespace GameComponents.Field
{
    public class FieldBorders : MonoBehaviour
    {
        [SerializeField]
        private Camera _sceneCamera;

        [SerializeField]
        private FieldSettings _settings;
        
        private Transform _transform;
        private Vector2 _worldScale;
        
        public void Initialize()
        {
            _transform = transform;
            
            SetWorldScale();
            SetBordersScale();
            SetBordersPosition();
        }

        private void SetWorldScale()
        {
            var sizeY = _sceneCamera.orthographicSize;
            var sizeX = _sceneCamera.aspect * sizeY;
            _worldScale = new Vector2(sizeX, sizeY);
        }

        private void SetBordersScale()
        {
            var scale = _worldScale;
            scale.y -= scale.y * _settings.TopOffset;
            _transform.localScale = scale;
        }

        private void SetBordersPosition()
        {
            var position = _transform.position;
            position.y -= _worldScale.y * _settings.TopOffset;
            _transform.position = position;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var ball = other.GetComponent<BallEntity>();
            EventBus.RaiseEvent<IBallSceneHandler>(a => a.OnDestroyBall(ball));
        }
    }
}