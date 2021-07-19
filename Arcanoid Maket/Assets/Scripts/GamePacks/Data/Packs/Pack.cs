using UnityEngine;

namespace GamePacks.Data.Packs
{
    [CreateAssetMenu(fileName = "New Pack", menuName = "Packs/Pack Data")]
    public class Pack : ScriptableObject
    {
        [SerializeField]
        private string _key;

        [SerializeField]
        private Sprite _icon;

        [SerializeField]
        private Color _color;

        [SerializeField]
        private TextAsset[] _levels;

        public string Key => _key;
        public Sprite Icon => _icon;
        public int LevelCount => _levels.Length;
        public Color Color => _color;

        public TextAsset GetLevelFileById(int id)
        {
            return _levels[id];
        }
    }
}