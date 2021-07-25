using MyLibrary.EventSystem;
using UnityEngine;

namespace EventInterfaces.BonusEvents.Bomb
{
    public interface IColorBombBonusHandler : IGlobalSubscriber
    {
        void OnActivateBonus(Vector2 position);
    }
}