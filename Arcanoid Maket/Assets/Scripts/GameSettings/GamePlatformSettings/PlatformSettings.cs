using Animations.Configs;
using UnityEngine;

namespace GameSettings.GamePlatformSettings
{
    public class PlatformSettings : MonoBehaviour
    {
        [SerializeField]
        private float _baseSpeed = 5f;

        [SerializeField]
        [Range(0.1f, 1.0f)]
        private float _baseRelativeSize = 0.25f;

        [SerializeField]
        private BaseAnimationConfig _valueConfig;
        
        public float BaseSpeed => _baseSpeed;
        public float BaseSize => _baseRelativeSize;
        public BaseAnimationConfig ValueConfig => _valueConfig;
    }
}