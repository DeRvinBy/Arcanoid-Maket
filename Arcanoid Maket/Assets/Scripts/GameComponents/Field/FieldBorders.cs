using EventInterfaces.BallEvents;
using EventInterfaces.BonusEvents;
using GameEntities.Ball;
using GameEntities.Bonuses;
using GameSettings.GameFieldSettings;
using MyLibrary.CollisionStorage.Colliders2D;
using MyLibrary.CollisionStorage.Extensions;
using MyLibrary.EventSystem;
using UnityEngine;

namespace GameComponents.Field
{
    public class FieldBorders : MonoBehaviour
    {
        [SerializeField]
        private Camera _sceneCamera;

        [SerializeField]
        private FieldSettings _settings;

        [SerializeField]
        private TriggerCollider2D _outCollider;
        
        private Transform _transform;
        private Vector2 _worldScale;

        private void OnEnable()
        {
            _outCollider.RegisterCollider(this);
            _outCollider.OnTriggerEnter += DestroyObjectOutBorders;
        }
        
        private void OnDisable()
        {
            _outCollider.UnregisterCollider(this);
            _outCollider.OnTriggerEnter -= DestroyObjectOutBorders;
        }

        private void DestroyObjectOutBorders(Collider2D other)
        {
            var ball = other.GetColliderMonoBehaviour<BallEntity>();
            if (ball != null)
            {
                EventBus.RaiseEvent<IBallSceneHandler>(a => a.OnDestroyBall(ball));
            }
            
            var bonus = other.GetColliderMonoBehaviour<BonusObject>();
            if (bonus != null)
            {
                EventBus.RaiseEvent<IBonusOnSceneHandler>(a => a.OnDestroyBonusObject(bonus));
            }
        }
        
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
    }
}