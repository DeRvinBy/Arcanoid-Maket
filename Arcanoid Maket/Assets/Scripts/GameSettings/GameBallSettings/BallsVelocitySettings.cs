using UnityEngine;

namespace GameSettings.GameBallSettings
{
    public class BallsVelocitySettings : MonoBehaviour
    {
        [SerializeField]
        private float _startVelocity = 6f;

        [SerializeField]
        private float _additionalVelocityPerBlock = 0.2f;

        [SerializeField]
        private float _maxAdditionalVelocity = 12f;

        public float MaxAdditionalVelocity => _maxAdditionalVelocity;

        public float AdditionalVelocityPerBlock => _additionalVelocityPerBlock;

        public float StartVelocity => _startVelocity;
    }
}