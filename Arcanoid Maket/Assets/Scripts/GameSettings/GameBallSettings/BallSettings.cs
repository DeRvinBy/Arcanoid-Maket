using MyLibrary.ObjectPool.Abstract;
using UnityEngine;

namespace GameSettings.GameBallSettings
{
    public class BallSettings : AbstractSettings
    {
        [SerializeField]
        private float _baseVelocity = 25f;

        [SerializeField]
        private int _ballDamage = 1;
        
        public float BaseVelocity => _baseVelocity;
        public int BallDamage => _ballDamage;
    }
}