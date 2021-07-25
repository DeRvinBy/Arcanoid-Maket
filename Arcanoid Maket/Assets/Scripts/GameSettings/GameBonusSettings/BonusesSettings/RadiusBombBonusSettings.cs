using UnityEngine;

namespace GameSettings.GameBonusSettings.BonusesSettings
{
    public class RadiusBombBonusSettings : MonoBehaviour
    {
        [SerializeField]
        [Min(1)]
        private int _bombDamage = 1;

        public int BombDamage => _bombDamage;
    }
}