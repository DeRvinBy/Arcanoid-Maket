using UnityEngine;

namespace GameSettings.GameBonusSettings.BonusesSettings
{
    public class DirectionBombBonusSettings : MonoBehaviour
    {
        [SerializeField]
        private float _blocksDestructionDelay = 0.2f;
        
        public float BlocksDestructionDelay => _blocksDestructionDelay;
    }
}