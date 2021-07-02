using UnityEngine;

namespace Project.Scripts.GameSettings.GamePlatformSettings
{
    public class PlatformSettings : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 5f;

        [SerializeField]
        private float _startSize = 2f;

        public float Speed => _speed;

        public float StartSize => _startSize;
    }
}