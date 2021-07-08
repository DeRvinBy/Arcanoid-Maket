using Project.Scripts.Architecture.Abstract;
using Project.Scripts.EventInterfaces.PacksEvents;
using Project.Scripts.EventInterfaces.StatesEvents;
using Project.Scripts.GameEntities.GameField.Components;
using Project.Scripts.GameSettings.GameFieldSettings;
using Project.Scripts.Packs.EventArguments;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.GameEntities.GameField
{
    public class FieldController : SceneEntitiesController, IMainGameStateStartHandler, ILevelChangedHandler
    {
        [SerializeField]
        private Camera _sceneCamera;
        
        [SerializeField]
        private FieldSettings _fieldSettings;
        
        [SerializeField]
        private FieldView _view;

        [SerializeField]
        private FieldBorders _borders;
        
        private FieldModel _model;

        public override void Initialize()
        {
            _model = new FieldModel();
            _model.Initialize(_sceneCamera, _fieldSettings);
            _borders.Initialize(_fieldSettings);
            _model.OnGameFieldLoaded += _view.DOCreateBlocksIn;

            EventBus.Subscribe(this);
        }

        public void OnStartGame()
        {
            _model.StartModel();
        }

        public void OnLevelChanged(LevelArguments levelArguments)
        {
            _model.SetupLevelDataFromFile(levelArguments.LevelFile);
        }
    }
}