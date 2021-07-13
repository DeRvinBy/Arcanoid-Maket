﻿using UnityEngine;

namespace Project.Scripts.Packs.Data.Packs
{
    [CreateAssetMenu(fileName = "New Pack", menuName = "Pack Data")]
    public class Pack : ScriptableObject
    {
        [SerializeField]
        private string _key;

        [SerializeField]
        private Sprite _icon;

        [SerializeField]
        private TextAsset[] _levels;

        public string Key => _key;

        public Sprite Icon => _icon;

        public int LevelCount => _levels.Length;
        
        public TextAsset GetLevelFileById(int id)
        {
            return _levels[id];
        }
    }
}