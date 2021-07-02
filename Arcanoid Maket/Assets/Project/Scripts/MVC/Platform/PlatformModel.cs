using Project.Scripts.GameSettings.GamePlatformSettings;

namespace Project.Scripts.MVC.Platform
{
    public class PlatformModel
    {
        public float Speed { get; private set; }
        public float Size { get; private set; }

        public void SetSpeed(float speed)
        {
            Speed = speed;
        }

        public void SetSize(float size)
        {
            Size = size;
        }
    }
}