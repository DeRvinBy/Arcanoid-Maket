using Scripts.GameSettings.GameFieldSettings;
using UnityEngine;

namespace Scripts.GameComponents.Field
{
    public class FieldProperties : MonoBehaviour
    {
        [SerializeField]
        private Camera _sceneCamera;
        
        [SerializeField]
        private FieldSettings _settings;

        public float GetCellMargin()
        {
            return _settings.CellMargin;
        }
        
        public Vector2 GetStartPosition()
        {
            var screenSideOffset = Screen.width * _settings.SideOffset;
            var screenTopOffset = Screen.height - (Screen.height * _settings.TopOffset);
            var screenPosition = new Vector2(screenSideOffset, screenTopOffset);
            return _sceneCamera.ScreenToWorldPoint(screenPosition);
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