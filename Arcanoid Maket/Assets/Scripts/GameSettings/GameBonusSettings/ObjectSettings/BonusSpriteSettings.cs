using System;
using GameEntities.Bonuses.Enumerations;
using UnityEngine;

namespace GameSettings.GameBonusSettings.ObjectSettings
{
    [Serializable]
    public class BonusSpriteSettings
    {
        [SerializeField]
        private BonusType _bonusType;

        [SerializeField]
        private Sprite _sprite;

        public Sprite Sprite => _sprite;
        public BonusType BonusType => _bonusType;
    }
}