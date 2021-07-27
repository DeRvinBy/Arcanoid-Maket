using UnityEngine;

namespace MyLibrary.Energy.Data.Config
{
    [CreateAssetMenu(fileName = "New Energy Config", menuName = "Energy/Energy Config")]
    public class EnergyConfig : ScriptableObject
    {
        [SerializeField]
        private int _maxEnergy = 30;
        
        [SerializeField]
        private int _energyPerTime = 1;

        [SerializeField]
        private int _restoringTimeInMinutes = 20;

        public int RestoringTimeInMinutes => _restoringTimeInMinutes;

        public int EnergyPerTime => _energyPerTime;

        public int MaxEnergy => _maxEnergy;
    }
}