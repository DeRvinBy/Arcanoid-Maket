using System;
using UnityEngine;

namespace Project.Scripts.GameSettings.GameBlockSettings
{
    [Serializable]
    public class IndividualBlockSettings
    {
        [SerializeField]
        private Sprite _blockSprite = null;

        public Sprite Sprite => _blockSprite;
    }
}