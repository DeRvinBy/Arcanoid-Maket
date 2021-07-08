using System;
using Project.Scripts.GameEntities.GameField.Data.Grid;
using Project.Scripts.GameEntities.GameField.Data.Level;
using Project.Scripts.GameSettings.GameFieldSettings;
using UnityEngine;

namespace Project.Scripts.GameEntities.GameField
{
    public class FieldModel
    {
        public event Action<FieldGrid> OnGameFieldLoaded;

        private LevelData _levelData;
        private FieldGrid _grid;
        private LevelParser _levelParser;
        
        public void Initialize(Camera camera, FieldSettings fieldSettings)
        {
            _grid = new FieldGrid(camera, fieldSettings);
            _levelParser = new LevelParser();
        }

        public void SetupLevelDataFromFile(TextAsset level)
        {
            _levelData = _levelParser.GetLevelDataFromJson(level.text);   
        }

        public void StartModel()
        {
            _grid.CreateGameField(_levelData);
            OnGameFieldLoaded?.Invoke(_grid);
        }
    }
}