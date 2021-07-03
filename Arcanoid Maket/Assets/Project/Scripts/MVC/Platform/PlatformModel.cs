using Project.Scripts.GameSettings.GamePlatformSettings;

namespace Project.Scripts.MVC.Platform
{
    public class PlatformModel
    {
        public float Speed { get; private set; }
        public float Size { get; private set; }

        private PlatformSettings _settings;

        public void Initialize(PlatformSettings settings)
        {
            _settings = settings;
        }

        public void StartModel()
        {
            Speed = _settings.Speed;
            Size = _settings.StartSize;
        }
    }
}