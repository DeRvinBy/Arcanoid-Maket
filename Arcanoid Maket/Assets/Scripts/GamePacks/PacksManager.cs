using EventInterfaces.PacksEvents;
using GamePacks.Data;
using GamePacks.Data.Level.LevelParser;
using GamePacks.Data.Level.LevelParser.Interfaces;
using GamePacks.Data.Level.LevelParser.Json;
using GamePacks.Data.Packs;
using MyLibrary.EventSystem;
using MyLibrary.Singleton;
using UnityEngine;

namespace GamePacks
{
    public class PacksManager : Singleton<PacksManager>
    {
        private const string PacksConfigPath = "Data/packs";
        private const string TilemapFilePath = "Data/tilemap";
        private const string DebugPack = "dog_pack";

        private PacksService _service;
        private ILevelParser _parser;

        private void OnApplicationQuit()
        {
            _service.SavePlayerPacks();
        }

        protected override void Initialize()
        {
            var config = Resources.Load<PacksConfig>(PacksConfigPath);
            _service = new PacksService();
            _service.Initialize(config);
            _service.StartDebugPack(DebugPack);
            var tilemap = Resources.Load<TextAsset>(TilemapFilePath);
            _parser = new JsonParser(tilemap.text);
            
            UpdatePacksInfo();
        }

        public bool IsSaveExist()
        {
            return _service.IsSaveExit();
        }
        
        public void UpdatePacksInfo()
        {
            var packsInfo = _service.GetPacksInfo();
            EventBus.RaiseEvent<IPacksInfoHandler>(a => a.OnPacksInfoUpdated(packsInfo));
        }

        public void PreparePack()
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

        public void SetCurrentPack(string packName)
        {
            _service.StartPack(packName);
        }
    }
}