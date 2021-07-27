using System;

namespace MyLibrary.Energy.Data.EnergySave
{
    public class EnergySaveItem
    {
        public int EnergySaveValue { get; set; }
        public DateTime TimeSaveValue { get; set; }
        public float RestoreProgress { get; set; }
    }
}