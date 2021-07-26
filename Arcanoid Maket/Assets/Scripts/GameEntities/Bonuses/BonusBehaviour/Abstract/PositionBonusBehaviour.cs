using GameEntities.Bonuses.Interfaces;
using UnityEngine;

namespace GameEntities.Bonuses.BonusBehaviour.Abstract
{
    public abstract class PositionBonusBehaviour : IBonusBehaviour
    {
        protected Vector2 _position;

        public PositionBonusBehaviour(Vector2 position)
        {
            _position = position;
        }
        
        public abstract void Action();
    }
}