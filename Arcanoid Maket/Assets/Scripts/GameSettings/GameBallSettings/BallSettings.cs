using MyLibrary.ObjectPool.Abstract;
using UnityEngine;

namespace GameSettings.GameBallSettings
{
    [CreateAssetMenu(fileName = "New Ball Settings", menuName = "Creator Settings/Ball Settings")]
    public class BallSettings : AbstractSettings
    {
        [SerializeField]
        private Sprite _ballSprite;

        [SerializeField]
        private int _ballDamage = 2;

        [SerializeField]
        private BallThresholdAngleSettings _verticalSettings;
        
        [SerializeField]
        private BallThresholdAngleSettings _horizontalSettings;

        public int BallDamage => _ballDamage;
        public Sprite BallSprite => _ballSprite;
        public BallThresholdAngleSettings VerticalSettings => _verticalSettings;
        public BallThresholdAngleSettings HorizontalSettings => _horizontalSettings;
    }
}