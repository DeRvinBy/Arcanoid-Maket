namespace Project.Scripts.MVC.Ball
{
    public class BallModel
    {
        public float Velocity { get; private set; }
        public float Damage { get; private set; }

        public void SetVelocity(float velocity)
        {
            Velocity = velocity;
        }

        public void SetDamage(float damage)
        {
            Damage = damage;
        }
    }
}