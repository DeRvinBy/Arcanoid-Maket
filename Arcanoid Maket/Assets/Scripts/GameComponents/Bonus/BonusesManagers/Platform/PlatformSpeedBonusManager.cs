using BehaviorControllers.EntitiesControllers;
using EventInterfaces.BonusEvents.Platform;
using EventInterfaces.StatesEvents;
using GameComponents.Bonus.Effects;
using GameEntities.Bonuses.Enumerations;
using MyLibrary.EventSystem;
using UnityEngine;

namespace GameComponents.Bonus.BonusesManagers.Platform
{
    public class PlatformSpeedBonusManager : MonoBehaviour, IPlatformSpeedBonusHandler, IPrepareGameplayHandler
    {
        [SerializeField]
        private PlatformController _platform;
        
        [SerializeField]
        private VariableValueEffect _bonusEffect;

        private void OnEnable()
        {
            EventBus.Subscribe(this);
            _bonusEffect.OnValueChanged += UpdatePlatformSpeed;
        }

        private void OnDisable()
        {
            EventBus.Subscribe(this);
            _bonusEffect.OnValueChanged -= UpdatePlatformSpeed;
        }
        
        public void OnActivateSpeedBonus(ValueModifer modifer)
        {
            _bonusEffect.ActivateEffect(modifer);
        }
        
        private void UpdatePlatformSpeed(float value)
        {
            _platform.SetAdditionalSpeed(value);
        }
        
        public void OnPrepareGame()
        {
            _bonusEffect.StopEffect();
        }
    }
}