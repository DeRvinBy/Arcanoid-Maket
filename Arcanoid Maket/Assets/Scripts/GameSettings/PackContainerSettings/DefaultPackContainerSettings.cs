using MyLibrary.ObjectPool.Abstract;
using UnityEngine;

namespace GameSettings.PackContainerSettings
{
    [CreateAssetMenu(fileName = "New Default Pack Container Settings", menuName = "Creator Settings/Default Pack Container Settings")]
    public class DefaultPackContainerSettings : AbstractSettings
    {
        [SerializeField]
        private Color _buttonColor = Color.gray;

        [SerializeField]
        private Sprite _packIcon;

        [SerializeField]
        private string _packKey = "unknown_pack";

        [SerializeField]
        private int _currentLevel = 0;

        public int CurrentLevel => _currentLevel;
        public string PackKey => _packKey;
        public Sprite PackIcon => _packIcon;
        public Color ButtonColor => _buttonColor;
    }
}