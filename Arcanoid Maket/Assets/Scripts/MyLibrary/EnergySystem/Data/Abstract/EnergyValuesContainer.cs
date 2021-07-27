using UnityEngine;

namespace MyLibrary.EnergySystem.Data.Abstract
{
    public abstract class EnergyValuesContainer : ScriptableObject
    {
        public abstract int GetCostById(int id);
    }
}