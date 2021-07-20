using MyLibrary.ObjectPool.Abstract;
using UnityEngine;

namespace GameSettings.GameBallSettings
{
    public class BallSettings : AbstractSettings
    {
        [SerializeField]
        private float _startVelocity = 25f;

        [SerializeField]
        private int _ballDamage = 1;
        
        public float StartVelocity => _startVelocity;
        public int BallDamage => _ballDamage;
    }
}