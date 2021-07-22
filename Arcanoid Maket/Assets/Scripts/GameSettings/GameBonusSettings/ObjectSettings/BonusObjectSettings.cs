using System.Collections.Generic;
using GameEntities.Bonuses.Enumerations;
using MyLibrary.ObjectPool.Abstract;
using UnityEngine;

namespace GameSettings.GameBonusSettings.ObjectSettings
{
    [CreateAssetMenu(fileName = "New Bonus Object Settings", menuName = "Creator Settings/Bonus Object Settings")]
    public class BonusObjectSettings : AbstractSettings
    {
        [SerializeField]
        private BonusSpriteSettings[] _spriteSettings;
        
        private Dictionary<BonusType, Sprite> _spriteSettingsMap;

        public void Initialize()
        {
            CreateSettingMap();
        }

        private void CreateSettingMap()
        {
            _spriteSettingsMap = new Dictionary<BonusType, Sprite>();
            foreach (var container in _spriteSettings)
            {
                _spriteSettingsMap.Add(container.BonusType, container.Sprite);
            }
        }
        
        public Sprite GetBonusSprite(BonusType bonusType)
        {
            return _spriteSettingsMap[bonusType];
        }
    }
}