using UnityEngine;

namespace GameSettings.GameBonusSettings.BonusesSettings
{
    public class RageBallBonusSettings : MonoBehaviour
    {
        [SerializeField]
        private float _effectTime = 2f;

        public float EffectTime => _effectTime;
    }
}