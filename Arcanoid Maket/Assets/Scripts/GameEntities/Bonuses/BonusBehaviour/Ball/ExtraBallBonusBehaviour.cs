using EventInterfaces.BonusEvents.Ball;
using GameEntities.Bonuses.BonusBehaviour.Abstract;
using GameEntities.Bonuses.Interfaces;
using MyLibrary.EventSystem;
using UnityEngine;

namespace GameEntities.Bonuses.BonusBehaviour.Ball
{
    public class ExtraBallBonusBehaviour : PositionBonusBehaviour
    {
        public ExtraBallBonusBehaviour(Vector2 position) : base(position)
        {
        }
        
        public override void Action()
        {
            EventBus.RaiseEvent<IExtraBallBonusHandler>(a => a.OnSpawnExtraBall(_position));
        }
    }
}