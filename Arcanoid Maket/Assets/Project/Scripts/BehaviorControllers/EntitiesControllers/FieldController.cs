using Project.Scripts.BehaviorControllers.Abstract;
using Project.Scripts.EventInterfaces.PacksEvents;
using Project.Scripts.GameComponents.Field;
using Project.Scripts.Packs.Data.Level;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.BehaviorControllers.EntitiesControllers
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