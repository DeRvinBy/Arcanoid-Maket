using Project.Scripts.EventInterfaces.GameFieldEvents;
using Project.Scripts.GameSettings.GameFieldSettings;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.GameEntities.GameField.Components
{
    public class FieldBorders : MonoBehaviour
    {
        [SerializeField]
        private Camera _sceneCamera;

        private Transform _transform;
        private FieldSettings _settings;
        private Vector2 _worldScale;
        
        public void Initialize(FieldSettings settings)
        {
            _settings = settings;
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
            EventBus.RaiseEvent<IBallOutBorderEvent>(a => a.OnBallOut());
        }
    }
}