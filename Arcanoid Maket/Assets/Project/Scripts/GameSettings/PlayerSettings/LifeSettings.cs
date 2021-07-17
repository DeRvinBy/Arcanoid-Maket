using Project.Scripts.GameEntities.PlayerLife.Components;
using UnityEngine;

namespace Project.Scripts.GameSettings.PlayerSettings
{
    public class LifeSettings : MonoBehaviour
    {
        [SerializeField]
        private LifeImageUI _prefab;
        
        [SerializeField]
        [Min(1)]
        private int _startLifeCount = 1;

        public LifeImageUI Prefab => _prefab;
        public int StartLifeCount => _startLifeCount;
    }
}