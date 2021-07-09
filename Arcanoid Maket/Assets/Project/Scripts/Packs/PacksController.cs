using Project.Scripts.BehaviorControllers.Abstract;
using Project.Scripts.EventInterfaces.GameEvents;
using Project.Scripts.EventInterfaces.PacksEvents;
using Project.Scripts.EventInterfaces.StatesEvents;
using Project.Scripts.Packs.Data.Game;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.Packs
{
    public class PacksController : EntityController, IPrepareStateHandler, ILevelCompleteHandler
    {
        [SerializeField]
        private GamePacks _gamePacks;

        private PacksModel _model;
        
        public override void Initialize()
        {
            _model = new PacksModel();
            _model.Initialize(_gamePacks);
            
            EventBus.Subscribe(this);
            _model.StartPack("test_pack");
        }
        
        public void OnPrepareGame()
        {
            StartPack();
            StartLevel();
        }

        public void StartPack()
        {
            var currentPack = _model.GetCurrentPack();
            
            EventBus.RaiseEvent<IPackChangedHandler>(a => a.OnPackChanged(currentPack));
        }

        public void StartLevel()
        {
            var levelId = _model.GetCurrentLevel();
            EventBus.RaiseEvent<ILevelChangedHandler>(a => a.OnLevelChanged(levelId));
            var levelFile = _model.GetCurrentLevelFile();
            EventBus.RaiseEvent<ILevelFileChangedHandler>(a => a.OnLevelFileChanged(levelFile));
        }

        public void OnLevelComplete()
        {
            _model.CompleteLevel();
            
            var currentPack = _model.GetCurrentPack();
            EventBus.RaiseEvent<IPackChangedHandler>(a => a.OnPackChanged(currentPack));
            var levelId = _model.GetCurrentLevel();
            EventBus.RaiseEvent<ILevelChangedHandler>(a => a.OnLevelChanged(levelId));
        }
    }
}