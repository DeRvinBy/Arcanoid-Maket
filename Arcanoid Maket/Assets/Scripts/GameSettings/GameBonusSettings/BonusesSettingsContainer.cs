using GameSettings.GameBonusSettings.BonusesSettings;
using UnityEngine;

namespace GameSettings.GameBonusSettings
{
    public class BonusesSettingsContainer : MonoBehaviour
    {
        [SerializeField]
        private BallSpeedBonusSettings _ballSpeedSettings;

        public BallSpeedBonusSettings BallSpeedSettings => _ballSpeedSettings;
    }
}