using GameEntities.Bonuses.Enumerations;
using MyLibrary.EventSystem;
using UnityEngine;

namespace EventInterfaces.BonusEvents.Bomb
{
    public interface IDirectionBombBonusHandler : IGlobalSubscriber
    {
        void OnActivateBonus(Vector2 position, BombBonusDirection direction);
    }
}