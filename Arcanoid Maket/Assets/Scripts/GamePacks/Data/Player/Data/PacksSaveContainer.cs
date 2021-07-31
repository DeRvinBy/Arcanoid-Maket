using System.Collections.Generic;

namespace GamePacks.Data.Player
{
    public class PacksSaveContainer
    {
        public string PackContainerKey { get; set; }
        public Dictionary<string, PackSaveItem> Packs { get; set; }
    }
}