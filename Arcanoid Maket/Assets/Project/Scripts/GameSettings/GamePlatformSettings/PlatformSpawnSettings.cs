using UnityEngine;

namespace Project.Scripts.GameSettings.GamePlatformSettings
{
    public class PlatformSpawnSettings : MonoBehaviour
    {
        [SerializeField]
        private float minAngle = -45f;

        [SerializeField]
        private float maxAngle = 45f;

        [SerializeField]
        private float delayToSpawnBall = 2f;

        public float RandomAngle => Random.Range(minAngle, maxAngle);

        public float DelayToSpawnBall => delayToSpawnBall;
    }
}