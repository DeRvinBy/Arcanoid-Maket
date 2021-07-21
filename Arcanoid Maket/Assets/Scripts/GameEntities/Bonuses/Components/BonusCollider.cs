using System;
using UnityEngine;

namespace GameEntities.Bonuses.Components
{
    public class BonusCollider : MonoBehaviour
    {
        public event Action OnTriggerEntered;

        private void OnTriggerEnter2D(Collider2D other)
        {
            OnTriggerEntered?.Invoke();
        }
    }
}