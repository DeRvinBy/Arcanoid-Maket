using System.Collections.Generic;
using System.Linq;
using GamePacks.Data.Level.LevelParser.Interfaces;
using GamePacks.Data.Level.LevelParser.Tiles;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace GamePacks.Data.Level.LevelParser.Json
{
    public class JsonLevelParser : ILevelParser
    {
        private int _horizontalCount;
        private int _verticalCount;
        private TileProperties[,] _data;

        private Dictionary<int, TileProperties> _tilePropertiesMap;
        
        public JsonLevelParser(string tilemapJson)
        {
            var tilePropertiesParser = new JsonTilePropertiesParser();
            _tilePropertiesMap = tilePropertiesParser.ParseTilePropertiesMap(tilemapJson);
        }
        
        public LevelData ParseLevelData(string text)
        {
            var level = JObject.Parse(text);
            ReadFieldSize(level);
            ReadLayerData(level);

            return new LevelData(_verticalCount, _horizontalCount, _data);
        }

        private void ReadFieldSize(JObject level)
        {
            _verticalCount = (int) level[JsonLevelTokens.LevelHeight];
            _horizontalCount = (int) level[JsonLevelTokens.LevelWidth];
        }

        private void ReadLayerData(JObject level)
        {
            var levelLayer = (JObject) level[JsonLevelTokens.Layers][JsonLevelTokens.LevelLayerID];
            var layerData = levelLayer[JsonLevelTokens.LayerData].Select(d => (int)d).ToArray();
            
            _data = new TileProperties[_verticalCount, _horizontalCount];

            for (int i = 0; i < _verticalCount; i++)
            {
                var line = i * _horizontalCount;
                for (int j = 0; j < _horizontalCount; j++)
                {
                    var tileId = layerData[line + j];
                    _data[i, j] = _tilePropertiesMap[tileId].GetCopy(); 
                }
            }
        }
    }
}