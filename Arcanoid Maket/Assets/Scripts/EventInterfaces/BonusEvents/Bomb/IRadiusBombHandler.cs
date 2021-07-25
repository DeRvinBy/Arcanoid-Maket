using MyLibrary.EventSystem;
using UnityEngine;

namespace EventInterfaces.BonusEvents.Bomb
{
    public interface IRadiusBombHandler : IGlobalSubscriber
    {
        void OnActivateBonus(Vector2 position);
    }
}