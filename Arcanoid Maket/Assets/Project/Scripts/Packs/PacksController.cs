using Project.Scripts.BehaviorControllers.Abstract;
using Project.Scripts.EventInterfaces.PacksEvents;
using Project.Scripts.EventInterfaces.StatesEvents;
using Project.Scripts.Packs.Data.Level.LevelParser;
using Project.Scripts.Packs.Data.Packs;
using Project.Scripts.Utils.EventSystem;
using Project.Scripts.Utils.Singleton;
using UnityEngine;

namespace Project.Scripts.Packs
{
    public class PacksController : Singleton<PacksController>, IPrepareGameplayHandler
    {
        [SerializeField]
        private PacksContainer _packsContainer;

        private PacksService _service;
        private ILevelParser _parser;

        private void OnApplicationQuit()
        {
            _service.SavePlayerPacks();
        }

        protected override void Initialize()
        {
            base.Initialize();
            
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
            var currentPack = _service.GetCurrentPackInfo();
            
            EventBus.RaiseEvent<IPackChangedHandler>(a => a.OnPackChanged(currentPack));
        }

        private void StartLevel()
        {
            var levelFile = _service.GetCurrentLevelFile();
            var levelData = _parser.ParseLevelData(levelFile.text);
            EventBus.RaiseEvent<ILevelFileChangedHandler>(a => a.OnLevelFileChanged(levelData));
        }

        public void CompleteLevel()
        {
            _service.CompleteLevel();
            
            var currentPack = _service.GetCurrentPackInfo();
            EventBus.RaiseEvent<IPackChangedHandler>(a => a.OnPackChanged(currentPack));
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