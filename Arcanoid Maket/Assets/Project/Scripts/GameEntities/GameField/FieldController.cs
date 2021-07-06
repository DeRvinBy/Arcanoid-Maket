using Project.Scripts.Architecture.Abstract;
using Project.Scripts.EventInterfaces.StatesEvents;
using Project.Scripts.GameEntities.GameField.Components;
using Project.Scripts.GameSettings.GameFieldSettings;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.GameEntities.GameField
{
    public class FieldController : SceneEntitiesController, IMainGameStateStartHandler
    {
        [SerializeField]
        private Camera _sceneCamera;
        
        [SerializeField]
        private FieldSettings _fieldSettings;
        
        [SerializeField]
        private FieldView _view;

        [SerializeField]
        private FieldBorders _borders;
        
        private FieldModel _fieldModel;

        public override void Initialize()
        {
            _fieldModel = new FieldModel();
            _fieldModel.Initialize(_sceneCamera, _fieldSettings);
            _borders.Initialize(_fieldSettings);
            _fieldModel.OnGameFieldLoaded += _view.CreateBlocksInField;

            EventBus.Subscribe(this);
        }

        public void OnStartGame()
        {
            _fieldModel.StartModel();
        }
    }
}