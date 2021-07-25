using EventInterfaces.BonusEvents.Bomb;
using GameEntities.Bonuses.BonusBehaviour.Abstract;
using GameEntities.Bonuses.Enumerations;
using MyLibrary.EventSystem;
using UnityEngine;

namespace GameEntities.Bonuses.BonusBehaviour.Bomb
{
    public class DirectionBombBonusBehaviour : PositionBonusBehaviour
    {
        private BombBonusDirection _direction;

        public DirectionBombBonusBehaviour(Vector2 position, BombBonusDirection direction) : base(position)
        {
            _direction = direction;
        }
        
        public override void Action()
        {
            EventBus.RaiseEvent<IDirectionBombBonusHandler>(a => a.OnActivateBonus(_position, _direction));
        }
    }
}