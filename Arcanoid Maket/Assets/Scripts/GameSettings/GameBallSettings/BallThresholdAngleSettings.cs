using System;
using UnityEngine;

namespace GameSettings.GameBallSettings
{
    [Serializable]
    public class BallThresholdAngleSettings
    {
        [SerializeField]
        private float _bounceAngleThreshold = 20f;
        
        [SerializeField]
        private float _bounceAngleChange = 25f;
        
        public float BounceAngleChange => _bounceAngleChange;
        public float BounceAngleThreshold => _bounceAngleThreshold;
    }
}