using UnityEngine;

namespace GameSettings.LifeSettings
{
    public class PlayerBallsSettings : MonoBehaviour
    {
        [SerializeField]
        [Min(1)]
        private int _startBallsCount = 3;
        public int StartBallsCount => _startBallsCount;
    }
}