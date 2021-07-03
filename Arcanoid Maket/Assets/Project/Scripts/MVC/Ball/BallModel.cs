using Project.Scripts.GameSettings.GameBallSettings;

namespace Project.Scripts.MVC.Ball
{
    public class BallModel
    {
        public float Velocity { get; private set; }
        public float Damage { get; private set; }

        private BallSettings _settings;

        public void Initialize(BallSettings settings)
        {
            _settings = settings;
        }

        public void SetupModel()
        {
            Velocity = _settings.StartVelocity;
            Damage = _settings.BallDamage;
        }
    }
}