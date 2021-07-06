using Project.Scripts.GameSettings.GameFieldSettings;
using Project.Scripts.GameStates.States.EventInterfaces;
using Project.Scripts.MVC.Abstract;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.MVC.GameField
{
    public class FieldController : SceneEntitiesController, IMainGameStateEvent
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

        public void StartGame()
        {
            _fieldModel.StartModel();
        }
    }
}