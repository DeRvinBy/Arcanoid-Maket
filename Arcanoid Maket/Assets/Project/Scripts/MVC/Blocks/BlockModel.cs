using System;

namespace Project.Scripts.MVC.Blocks
{
    public class BlockModel
    {
        public Action<int> OnBlockLifeChanged;

        private int _life;

        public void SetLife(int life)
        {
            _life = life;
        }

        public void ReduceLife(int value)
        {
            _life -= value;
            
            OnBlockLifeChanged?.Invoke(_life);
        }
    }
}