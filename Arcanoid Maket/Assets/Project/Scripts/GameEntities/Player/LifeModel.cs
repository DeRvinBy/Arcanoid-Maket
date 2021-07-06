using Project.Scripts.GameSettings.PlayerSettings;

namespace Project.Scripts.GameEntities.Player
{
    public class LifeModel
    {
        public int LifeCount { get; private set; }

        public void Initialize(LifeSettings settings)
        {
            LifeCount = settings.StartLifeCount;
        }

        public void ReduceLifeByOne()
        {
            LifeCount--;
        }
    }
}