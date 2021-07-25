using GameEntities.Bonuses.Enumerations;
using MyLibrary.EventSystem;
using UnityEngine;

namespace EventInterfaces.BonusEvents.Bomb
{
    public interface IDirectionBombBonusHandler : IGlobalSubscriber
    {
        void OnActivateDirectionBombBonus(Vector2 position, BombBonusDirection direction);
    }
}