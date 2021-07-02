using System;

namespace Project.Scripts.MVC.Blocks
{
    public class BlockModel
    {
        public Action OnBlockLifeEnded;

        private int _life;

        public void SetLife(int life)
        {
            _life = life;
        }

        public void ReduceLife(int value)
        {
            _life -= value;

            if (_life < 0)
            {
                OnBlockLifeEnded?.Invoke();
            }
        }
    }
}