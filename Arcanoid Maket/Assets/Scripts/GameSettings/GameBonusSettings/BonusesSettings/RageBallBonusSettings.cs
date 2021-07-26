using UnityEngine;

namespace GameSettings.GameBonusSettings.BonusesSettings
{
    public class RageBallBonusSettings : MonoBehaviour
    {
        [SerializeField]
        private Sprite _rageBallSprite;
        
        [SerializeField]
        private float _effectTime = 2f;

        public float EffectTime => _effectTime;
        public Sprite RageBallSprite => _rageBallSprite;
    }
}