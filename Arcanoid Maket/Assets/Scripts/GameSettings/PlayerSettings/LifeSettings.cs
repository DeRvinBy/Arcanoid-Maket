using Scripts.UI.Header.LifeUI;
using UnityEngine;

namespace Scripts.GameSettings.PlayerSettings
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