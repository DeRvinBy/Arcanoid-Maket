namespace Scripts.GamePacks.Data.Packs
{
    public class PackInfo
    {
        public Pack GamePack { get; set; }
        public bool IsOpen { get; set; }
        public bool IsComplete { get; set; }
        public int CurrentLevel { get; set; }
        public int PackProgressLevel{ get; set; }
        public bool IsPackReplayed { get; set; }
        public bool IsLastPack { get; set; }
    }
}