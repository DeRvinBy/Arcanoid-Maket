using System.Collections.Generic;
using GamePacks.Data;
using GamePacks.Data.Config;
using GamePacks.Data.Level;
using GamePacks.Data.Level.LevelParser.Interfaces;
using GamePacks.Data.Level.LevelParser.Json;
using GamePacks.Data.Packs;
using GamePacks.Data.Player;
using GamePacks.Data.Player.SaveLoadManagers;
using GamePacks.DebugPacks;
using MyLibrary.Singleton;
using UnityEngine;

namespace GamePacks
{
    public class PacksManager : Singleton<PacksManager>
    {
        private const string PacksConfigPath = "Data/packsConfig";
        private const string TilemapFilePath = "Data/tilemap";

        private PacksConfig _config;
        private PlayerPacks _playerPacks;
        private PacksService _service;
        private ILevelParser _parser;
        private bool _isSaveExist;

        private void OnApplicationPause(bool pauseStatus)
        {
            _playerPacks.SavePacks();
        }
        
        protected override void OnApplicationQuit()
        {
            base.OnApplicationQuit();
            _playerPacks.SavePacks();
        }

        protected override void Initialize()
        {
            _config = Resources.Load<PacksConfig>(PacksConfigPath);
            
            var saveLoadManager = new PlayerPrefsPacksSaveLoadManager(_config.PacksContainerKey);
            _playerPacks = new PlayerPacks();
            _playerPacks.Initialize(saveLoadManager, _config.GetPacksMap());
            _isSaveExist = saveLoadManager.IsSaveExist();
            
            _service = new PacksService();
            _service.Initialize(_playerPacks, _config);
            
            var tilemap = Resources.Load<TextAsset>(TilemapFilePath);
            _parser = new JsonLevelParser(tilemap.text);
            
            
#if UNITY_EDITOR
            var debugHandler = gameObject.AddComponent<DebugPacksHandler>();
            debugHandler.Initialize(_config, _service, _isSaveExist);
#endif
        }

        public bool IsSaveExist()
        {
            return _isSaveExist;
        }
        
        public PackInfo GetCurrentPackInfo()
        {
            return _service.GetCurrentPackInfo();
        }
        
        public Dictionary<string, PackInfo> GetPacksInfo()
        {
            return _service.GetPacksInfo();
        }

        public LevelData GetCurrentLevel()
        {
            var levelFile = _service.GetCurrentLevelFile();
            return _parser.ParseLevelData(levelFile.text);
        }
        
        public void SetupFirstPack()
        {
            _service.StartPack(_config.FirstPackKey);
        }
        
        public void SetCurrentPack(string packName)
        {
            _service.StartPack(packName);
        }

        public void CompleteLevel()
        {
            _service.CompleteLevel();
        }
    }
}