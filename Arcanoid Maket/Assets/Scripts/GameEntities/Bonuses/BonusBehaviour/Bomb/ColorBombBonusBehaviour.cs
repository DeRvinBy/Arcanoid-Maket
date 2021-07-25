using EventInterfaces.BonusEvents.Bomb;
using GameEntities.Bonuses.BonusBehaviour.Abstract;
using MyLibrary.EventSystem;
using UnityEngine;

namespace GameEntities.Bonuses.BonusBehaviour.Bomb
{
    public class ColorBombBonusBehaviour : PositionBonusBehaviour
    {
        public ColorBombBonusBehaviour(Vector2 position) : base(position)
        {
        }

        public override void Action()
        {
            EventBus.RaiseEvent<IColorBombBonusHandler>(a => a.OnActivateBonus(_position));
        }
    }
}