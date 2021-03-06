using UnityEngine;

namespace GameSettings.GameBonusSettings.BonusesSettings
{
    public class RadiusBombBonusSettings : BombDestructionSettings
    {
        [SerializeField]
        [Min(1)]
        private int _bombDamage = 1;

        public int BombDamage => _bombDamage;
    }
}