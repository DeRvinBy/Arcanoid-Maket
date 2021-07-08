namespace Project.Scripts.GameEntities.Player
{
    public class LifeModel
    {
        public int LifeCount { get; private set; }

        public void SetLifeCount(int lifeCount)
        {
            LifeCount = lifeCount;
        }

        public void ReduceLifeByOne()
        {
            LifeCount--;
        }
    }
}