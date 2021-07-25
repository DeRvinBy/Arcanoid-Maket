using BehaviorControllers.Abstract;
using EventInterfaces.FieldEvents;
using EventInterfaces.StatesEvents;
using GameComponents.Field;
using GamePacks;
using MyLibrary.EventSystem;
using UnityEngine;

namespace BehaviorControllers.EntitiesControllers
{
    public class FieldController : EntityController, IPrepareGameplayHandler
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

        public void OnPrepareGame()
        {
            var levelData = PacksManager.Instance.GetCurrentLevel();
            _fieldGrid.CreateGameField(levelData);
            EventBus.RaiseEvent<IFieldGridHandler>(a => a.OnFieldGridCreated(_fieldGrid));
            _creator.CreateBlocksInGameField(_fieldGrid);
        }
    }
}