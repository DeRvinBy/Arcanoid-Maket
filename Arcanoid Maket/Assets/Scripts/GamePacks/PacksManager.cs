using System;
using System.Collections.Generic;
using GamePacks.Data;
using GamePacks.Data.Level;
using GamePacks.Data.Level.LevelParser.Interfaces;
using GamePacks.Data.Level.LevelParser.Json;
using GamePacks.Data.Packs;
using MyLibrary.Singleton;
using UnityEngine;

namespace GamePacks
{
    public class PacksManager : Singleton<PacksManager>
    {
        private const string PacksConfigPath = "Data/Packs/build_packs";
        private const string TilemapFilePath = "Data/tilemap";

        private PacksService _service;
        private ILevelParser _parser;

        private void OnApplicationPause(bool pauseStatus)
        {
            _service.SavePlayerPacks();
        }

        protected override void Initialize()
        {
            var config = Resources.Load<PacksConfig>(PacksConfigPath);
            _service = new PacksService();
            _service.Initialize(config);
            
#if UNITY_EDITOR
            if (_service.IsSaveExit())
            {
                _service.StartDebugPack(config.DebugPack, config.DebugLevelId);
            }         
#endif
            
            var tilemap = Resources.Load<TextAsset>(TilemapFilePath);
            _parser = new JsonParser(tilemap.text);
        }

        [ContextMenu("Complete all packs")]
        public void CompleteAllPacks()
        {
            _service.CompleteAllPacks();
        }

        public bool IsSaveExist()
        {
            return _service.IsSaveExit();
        }
        
        public Dictionary<string, PackInfo> GetPacksInfo()
        {
            return _service.GetPacksInfo();
        }

        public PackInfo GetCurrentPackInfo()
        {
            return _service.GetCurrentPackInfo();
        }

        public LevelData GetCurrentLevel()
        {
            var levelFile = _service.GetCurrentLevelFile();
            return _parser.ParseLevelData(levelFile.text);
        }

        public void CompleteLevel()
        {
            _service.CompleteLevel();
        }

        public void SetCurrentPack(string packName)
        {
            _service.StartPack(packName);
        }
    }
}