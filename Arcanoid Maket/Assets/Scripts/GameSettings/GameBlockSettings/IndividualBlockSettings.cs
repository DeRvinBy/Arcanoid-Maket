using System;
using UnityEngine;

namespace Scripts.GameSettings.GameBlockSettings
{
    [Serializable]
    public class IndividualBlockSettings
    {
        [SerializeField]
        private Sprite _blockSprite;

        [SerializeField]
        private Color _particleColor;
        
        public Sprite Sprite => _blockSprite;
        public Color ParticleColor => _particleColor;
    }
}