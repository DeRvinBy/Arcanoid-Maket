using Scripts.GameSettings.GamePlatformSettings;

namespace Scripts.GameComponents.Platform.Data
{
    public class PlatformProperties
    {
        public float Speed { get; private set; }
        public float Size { get; private set; }

        public void SetupProperties(PlatformSettings settings)
        {
            Speed = settings.Speed;
            Size = settings.StartSize;
        }
    }
}