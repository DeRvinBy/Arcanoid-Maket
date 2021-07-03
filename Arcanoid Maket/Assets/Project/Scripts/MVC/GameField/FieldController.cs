using Project.Scripts.EventInterfaces.StatesInterfaces;
using Project.Scripts.GameSettings.GameFieldSettings;
using Project.Scripts.MVC.Abstract;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.MVC.GameField
{
    public class FieldController : SceneEntitiesController, IMainGameStateEvent
    {
        [SerializeField]
        private Camera _sceneCamera = null;
        
        [SerializeField]
        private FieldSettings _fieldSettings = null;
        
        [SerializeField]
        private FieldView _fieldView = null;

        [SerializeField]
        private FieldBorders _borders;
        
        private FieldModel _fieldModel;

        public override void Initialize()
        {
            _fieldModel = new FieldModel();
            _fieldModel.Initialize(_sceneCamera, _fieldSettings);
            _fieldModel.OnGameFieldCreated += _fieldView.CreateBlocksInField;
            _borders.Initialize(_fieldSettings);

            EventBus.Subscribe(this);
        }

        public void StartController()
        {
            _fieldModel.StartModel();
        }
    }
}