using UnityEngine;

namespace Project.Scripts.GameSettings.GameFieldSettings
{
    public class FieldSettings : MonoBehaviour
    {
        [SerializeField]
        [Range(0f, 0.25f)]
        private float _topOffset = 0.15f;

        [SerializeField]
        [Range(1f, 2f)]
        private float _blockAspect = 1.5f;
        
        [SerializeField]
        [Range(0f, 0.4f)]
        private float _sideOffset = 0.1f;

        [SerializeField]
        [Min(0f)]
        private float _cellMargin = 0.05f;
        
        public float TopOffset => _topOffset;
        public float SideOffset => _sideOffset;
        public float CellMargin => _cellMargin;

        public float BlockAspect => _blockAspect;
    }
}