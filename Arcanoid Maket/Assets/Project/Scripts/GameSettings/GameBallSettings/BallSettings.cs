using UnityEngine;

namespace Project.Scripts.GameSettings.GameBallSettings
{
    public class BallSettings : MonoBehaviour
    {
        [SerializeField]
        private float _startVelocity = 25f;

        [SerializeField]
        private int _ballDamage = 1;
        
        public float StartVelocity => _startVelocity;
        public int BallDamage => _ballDamage;
    }
}