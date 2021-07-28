using System.Collections.Generic;
using MyLibrary.EnergySystem.Data.Abstract;
using UnityEngine;

namespace GameComponents.Energy.Config
{
    [CreateAssetMenu(fileName = "New Energy Values Config", menuName = "Energy/Energy Values Config")]
    public class GameEnergyValuesContainer : EnergyValuesContainer
    {
        [SerializeField]
        private GameEnergyValue[] _energyValues;

        private Dictionary<int, int> _energyValuesMap;
        
        public override int GetCostById(int id)
        {
            if (_energyValuesMap == null)
            {
                CreateEnergyValuesMap();
            }

            return _energyValuesMap[id];
        }

        private void CreateEnergyValuesMap()
        {
            _energyValuesMap = new Dictionary<int, int>();
            foreach (var energyValue in _energyValues)
            {
                _energyValuesMap.Add((int)energyValue.TypeAction, energyValue.EnergyValue);
            }
        }
    }
}