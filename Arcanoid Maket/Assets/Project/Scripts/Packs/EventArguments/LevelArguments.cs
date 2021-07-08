using UnityEngine;

namespace Project.Scripts.Packs.EventArguments
{
    public class LevelArguments
    {
        public int CurrentLevel { get; set; }
        public int LevelCountInPack { get; set; }
        public TextAsset LevelFile { get; set; }
    }
}