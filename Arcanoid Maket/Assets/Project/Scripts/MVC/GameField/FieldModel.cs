using Project.Scripts.GameSettings.GameFieldSettings;
using Project.Scripts.MVC.GameField.Data.Grid;
using Project.Scripts.MVC.GameField.Data.Level;
using UnityEngine;


namespace Project.Scripts.MVC.GameField
{
    public class FieldModel
    {
        public FieldGrid Grid { get; private set; }

        private LevelParser _levelParser;
        
        public void Initialize(Camera camera, FieldSettings fieldSettings)
        {
            Grid = new FieldGrid(camera, fieldSettings);
            _levelParser = new LevelParser();
        }

        public void StartModel()
        {
            var levelData = _levelParser.GetLevelDataFromFile("Levels/pack1", 2);
            Grid.CreateGameField(levelData);
        }
    }
}