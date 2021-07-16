using Project.Scripts.BehaviorControllers.Abstract;
using Project.Scripts.EventInterfaces.PacksEvents;
using Project.Scripts.EventInterfaces.StatesEvents;
using Project.Scripts.Packs.Data.Level.LevelParser;
using Project.Scripts.Packs.Data.Packs;
using Project.Scripts.Utils.EventSystem;
using UnityEngine;

namespace Project.Scripts.Packs
{
    public class PacksController : EntityController, IPrepareGameplayHandler
    {
        [SerializeField]
        private PacksContainer _packsContainer;

        private PacksService _service;
        private ILevelParser _parser;
        
        public override void Initialize()
        {
            _service = new PacksService();
            _service.Initialize(_packsContainer);
            _parser = new JsonParser();
            
            EventBus.Subscribe(this);
            UpdatePacksInfo();
        }
        
        public void OnPrepareGame()
        {
            StartPack();
            StartLevel();
        }

        private void StartPack()
        {
            var currentPack = _service.GetCurrentPack();
            
            EventBus.RaiseEvent<IPackChangedHandler>(a => a.OnPackChanged(currentPack));
        }

        private void StartLevel()
        {
            var levelId = _service.GetCurrentLevel();
            EventBus.RaiseEvent<ILevelChangedHandler>(a => a.OnLevelChanged(levelId));
            var levelFile = _service.GetCurrentLevelFile();
            var levelData = _parser.ParseLevelData(levelFile.text);
            EventBus.RaiseEvent<ILevelFileChangedHandler>(a => a.OnLevelFileChanged(levelData));
        }

        public void CompleteLevel()
        {
            _service.CompleteLevel();
            
            var currentPack = _service.GetCurrentPack();
            EventBus.RaiseEvent<IPackChangedHandler>(a => a.OnPackChanged(currentPack));
            var levelId = _service.GetCurrentLevel();
            EventBus.RaiseEvent<ILevelChangedHandler>(a => a.OnLevelChanged(levelId));
        }

        public void UpdatePacksInfo()
        {
            var packsInfo = _service.GetPacksInfo();
            EventBus.RaiseEvent<IPacksInfoHandler>(a => a.OnPacksInfoUpdated(packsInfo));
        }

        public void SetCurrentPack(string packName)
        {
            _service.StartPack(packName);
        }
    }
}