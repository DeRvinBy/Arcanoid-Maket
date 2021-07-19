using BehaviorControllers.Abstract;
using EventInterfaces.PacksEvents;
using GameComponents.Field;
using GamePacks.Data.Level;
using Library.EventSystem;
using UnityEngine;

namespace BehaviorControllers.EntitiesControllers
{
    public class FieldController : EntityController, ILevelFileChangedHandler
    {
        [SerializeField]
        private FieldProperties _properties;
        
        [SerializeField]
        private FieldCreator _creator;

        [SerializeField]
        private FieldBorders _borders;

        private FieldGrid _fieldGrid;

        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(this);
        }

        public override void Initialize()
        {
            _fieldGrid = new FieldGrid();
            _properties.Initialize();
            _fieldGrid.Initialize(_properties);
            _borders.Initialize();
        }

        public void OnLevelFileChanged(LevelData levelData)
        {
            _fieldGrid.CreateGameField(levelData);
            _creator.CreateBlocksInGameField(_fieldGrid);
        }
    }
}