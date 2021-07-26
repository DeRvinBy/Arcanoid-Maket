using EventInterfaces.BonusEvents.Bomb;
using GameEntities.Bonuses.BonusBehaviour.Abstract;
using MyLibrary.EventSystem;
using UnityEngine;

namespace GameEntities.Bonuses.BonusBehaviour.Bomb
{
    public class RadiusBombBonusBehaviour : PositionBonusBehaviour
    {
        public RadiusBombBonusBehaviour(Vector2 position) : base(position)
        {
        }

        public override void Action()
        {
            EventBus.RaiseEvent<IRadiusBombHandler>(a => a.OnActivateBonus(_position));
        }
    }
}