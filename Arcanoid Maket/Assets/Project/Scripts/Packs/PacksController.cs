using Project.Scripts.Architecture.Abstract;
using Project.Scripts.EventInterfaces.GameEvents;
using Project.Scripts.EventInterfaces.PacksEvents;
using Project.Scripts.Packs.Data.Game;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.Packs
{
    public class PacksController : SceneEntitiesController, IPrepareGameHandler, IWinGameHandler
    {
        [SerializeField]
        private GamePacks _gamePacks;

        private PacksModel _model;
        
        public override void Initialize()
        {
            _model = new PacksModel();
            _model.Initialize(_gamePacks);
            
            EventBus.Subscribe(this);
        }
        
        public void OnPrepareGame()
        {
            StartPack("test");
            StartLevel();
        }

        public void StartPack(string packName)
        {
            _model.StartPack(packName);
            var currentPack = _model.GetCurrentPack();
            
            EventBus.RaiseEvent<IPackChangedHandler>(a => a.OnPackChanged(currentPack));
        }

        public void StartLevel()
        {
            var levelArgs = _model.GetLevelArguments();
            EventBus.RaiseEvent<ILevelChangedHandler>(a => a.OnLevelChanged(levelArgs));
        }

        public void OnWinGame()
        {
            _model.CompleteLevel();
            var currentPack = _model.GetCurrentPack();
            EventBus.RaiseEvent<IPackChangedHandler>(a => a.OnPackChanged(currentPack));
            var levelArgs = _model.GetLevelArguments();
            EventBus.RaiseEvent<ILevelChangedHandler>(a => a.OnLevelChanged(levelArgs));
        }
    }
}