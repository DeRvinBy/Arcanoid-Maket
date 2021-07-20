using System;
using UnityEngine;

namespace GameSettings.GameBlockSettings.Indestructible
{
    [Serializable]
    public class IndestructibleBlockSettings
    {
        [SerializeField]
        private Sprite _sprite;

        public Sprite Sprite => _sprite;
    }
}