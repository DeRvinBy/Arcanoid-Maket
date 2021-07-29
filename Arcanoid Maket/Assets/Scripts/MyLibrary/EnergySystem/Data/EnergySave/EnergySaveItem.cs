using System;

namespace MyLibrary.EnergySystem.Data.EnergySave
{
    public class EnergySaveItem
    {
        public int EnergySaveValue { get; set; }
        public DateTime TimeSaveValue { get; set; }
        public float RestoreProgress { get; set; }
    }
}