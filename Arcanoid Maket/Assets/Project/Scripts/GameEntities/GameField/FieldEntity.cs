using Project.Scripts.BehaviorControllers.Abstract;
using Project.Scripts.EventInterfaces.PacksEvents;
using Project.Scripts.GameEntities.GameField.Components;
using Project.Scripts.GameEntities.GameField.Data.Grid;
using Project.Scripts.Packs.Data.Level;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.GameEntities.GameField
{
    public class FieldEntity : EntityController, ILevelFileChangedHandler
    {
        [SerializeField]
        private FieldProperties _properties;
        
        [SerializeField]
        private FieldCreator _creator;

        [SerializeField]
        private FieldBorders _borders;

        private FieldGrid _fieldGrid;

        public override void Initialize()
        {
            _fieldGrid = new FieldGrid(_properties);
            _borders.Initialize();

            EventBus.Subscribe(this);
        }

        public void OnLevelFileChanged(LevelData levelData)
        {
            _fieldGrid.CreateGameField(levelData);
            _creator.CreateBlocksInGameField(_fieldGrid);
        }
    }
}