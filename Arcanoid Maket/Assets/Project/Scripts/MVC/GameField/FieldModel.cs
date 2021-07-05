using System;
using Project.Scripts.GameSettings.GameFieldSettings;
using Project.Scripts.MVC.GameField.Data.Grid;
using Project.Scripts.MVC.GameField.Data.Level;
using UnityEngine;


namespace Project.Scripts.MVC.GameField
{
    public class FieldModel
    {
        public event Action<FieldGrid> OnGameFieldCreated;

        private FieldGrid _grid;
        private LevelParser _levelParser;
        
        public void Initialize(Camera camera, FieldSettings fieldSettings)
        {
            _grid = new FieldGrid(camera, fieldSettings);
            _levelParser = new LevelParser();
        }

        public void StartModel()
        {
            var levelData = _levelParser.GetLevelDataFromFile("Levels/pack1", 1);
            _grid.CreateGameField(levelData);
            OnGameFieldCreated?.Invoke(_grid);
        }
    }
}