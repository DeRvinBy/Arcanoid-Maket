using Project.Scripts.GameSettings.GamePlatformSettings;

namespace Project.Scripts.MVC.Platform
{
    public class PlatformModel
    {
        public float Speed { get; private set; }
        public float Size { get; private set; }

        public void Initialize(PlatformSettings settings)
        {
            Speed = settings.Speed;
            Size = settings.StartSize;
        }
    }
}