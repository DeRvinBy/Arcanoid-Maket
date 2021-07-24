using EventInterfaces.BonusEvents.Bomb;
using GameEntities.Bonuses.Enumerations;
using GameEntities.Bonuses.Interfaces;
using MyLibrary.EventSystem;
using UnityEngine;

namespace GameEntities.Bonuses.BonusBehaviour.Bomb
{
    public class DirectionBombBonusBehaviour : IBonusBehaviour
    {
        private Vector2 _position;
        private BombBonusDirection _direction;

        public DirectionBombBonusBehaviour(Vector2 position, BombBonusDirection direction)
        {
            _position = position;
            _direction = direction;
        }
        
        public void Action()
        {
            EventBus.RaiseEvent<IDirectionBombBonusHandler>(a => a.OnActivateBonus(_position, _direction));
        }
    }
}