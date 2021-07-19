using UnityEngine;

namespace GameSettings.LifeSettings
{
    public class LifeSettings : MonoBehaviour
    {
        [SerializeField]
        [Min(1)]
        private int _startLifeCount = 1;
        public int StartLifeCount => _startLifeCount;
    }
}