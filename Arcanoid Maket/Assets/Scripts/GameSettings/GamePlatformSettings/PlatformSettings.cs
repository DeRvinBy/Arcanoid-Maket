using UnityEngine;

namespace GameSettings.GamePlatformSettings
{
    public class PlatformSettings : MonoBehaviour
    {
        [SerializeField]
        private float _baseSpeed = 5f;

        [SerializeField]
        private float _startSize = 2f;

        public float BaseSpeed => _baseSpeed;
        public float StartSize => _startSize;
    }
}