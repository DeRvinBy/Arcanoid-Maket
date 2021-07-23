using EventInterfaces.BonusEvents;
using GameEntities.Bonuses.Interfaces;
using MyLibrary.EventSystem;
using UnityEngine;

namespace GameEntities.Bonuses.BonusBehaviour
{
    public class ExtraBallBonusBehaviour : IBonusBehaviour
    {
        private Vector2 _spawnPosition;
        
        public ExtraBallBonusBehaviour(Vector2 spawnPosition)
        {
            _spawnPosition = spawnPosition;
        }
        
        public void Action()
        {
            EventBus.RaiseEvent<IExtraBallBonusHandler>(a => a.OnSpawnExtraBall(_spawnPosition));
        }
    }
}