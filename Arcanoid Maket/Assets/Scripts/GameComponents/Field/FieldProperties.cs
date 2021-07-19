using EventInterfaces.FieldEvents;
using GameSettings.GameFieldSettings;
using Library.EventSystem;
using UnityEngine;

namespace GameComponents.Field
{
    public class FieldProperties : MonoBehaviour
    {
        [SerializeField]
        private Camera _sceneCamera;
        
        [SerializeField]
        private FieldSettings _settings;

        private Vector2 _startPosition;

        public void Initialize()
        {
            var fieldHeight = Screen.height - Screen.height * _settings.TopOffset;
            EventBus.RaiseEvent<IFieldPropertiesHandler>(a => a.OnFieldScreenHeightSetup(fieldHeight));
            SetupStartPosition(fieldHeight);
        }

        private void SetupStartPosition(float fieldHeight)
        {
            var screenSideOffset = Screen.width * _settings.SideOffset;
            var screenPosition = new Vector2(screenSideOffset, fieldHeight);
            _startPosition = _sceneCamera.ScreenToWorldPoint(screenPosition);
        }
        
        public float GetCellMargin()
        {
            return _settings.CellMargin;
        }

        public Vector2 GetStartPosition()
        {
            return _startPosition;
        }

        public Vector2 GetCellSize(int horizontalCount)
        {
            var worldHeight = _sceneCamera.orthographicSize * 2f;
            var worldWidth = worldHeight * _sceneCamera.aspect;
            worldWidth -= worldWidth * _settings.SideOffset * 2f;
            var sizeX = (worldWidth - _settings.CellMargin * (horizontalCount - 1)) / horizontalCount;
            var sizeY = sizeX / _settings.BlockAspect;
            return new Vector2(sizeX, sizeY);
        }
    }
}