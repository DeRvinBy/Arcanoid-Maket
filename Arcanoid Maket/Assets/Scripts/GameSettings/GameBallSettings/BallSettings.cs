using MyLibrary.ObjectPool.Abstract;
using UnityEngine;

namespace GameSettings.GameBallSettings
{
    [CreateAssetMenu(fileName = "New Ball Settings", menuName = "Creator Settings/Ball Settings")]
    public class BallSettings : AbstractSettings
    {
        [SerializeField]
        private float _baseVelocity = 6f;

        [SerializeField]
        private int _ballDamage = 2;
        
        public float BaseVelocity => _baseVelocity;
        public int BallDamage => _ballDamage;
    }
}