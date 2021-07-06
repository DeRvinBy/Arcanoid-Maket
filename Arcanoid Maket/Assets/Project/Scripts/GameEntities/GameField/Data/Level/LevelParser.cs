using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Project.Scripts.GameEntities.GameField.Data.Level
{
    public class LevelParser
    {
        private int _leftStart;
        private int _leftEnd;
        private int _topStart;
        private int _topEnd;
        
        private int _horizontalCount;
        private int _verticalCount;

        private int[,] _data;
        
        public LevelData GetLevelDataFromFile(string path, int levelID)
        {
            var jsonFile = Resources.Load<TextAsset>(path);
            var jsonObject = JObject.Parse(jsonFile.text);

            var layer = (JObject) jsonObject[JsonTokens.Layers][levelID];
            ReadLayerProperties(layer);
            ReadLayerData(layer);

            return new LevelData(_verticalCount, _horizontalCount, _data);
        }

        private void ReadLayerProperties(JObject layer)
        {
            var properties = layer[JsonTokens.Properties].Children();
            _leftStart = GetPropertyValue(properties, JsonTokens.KeyLeftStart);
            _leftEnd = GetPropertyValue(properties, JsonTokens.KeyLeftEnd);
            _topStart = GetPropertyValue(properties, JsonTokens.KeyTopStart);
            _topEnd = GetPropertyValue(properties, JsonTokens.KeyTopEnd);
            _verticalCount = _topEnd - _topStart + 1;
            _horizontalCount = _leftEnd - _leftStart + 1;
        }
        
        private int GetPropertyValue(IEnumerable<JToken> properties, string key)
        {
            return (int)properties.First(t => (string) t[JsonTokens.PropertyName] == key)[JsonTokens.PropertyValue];
        }

        private void ReadLayerData(JObject layer)
        {
            var layerData = layer[JsonTokens.LayerData].Select(d => (int)d).ToArray();
            var layerWidth = (int) layer[JsonTokens.LayerWidth];
            _data = new int[_verticalCount, _horizontalCount];

            for (int i = 0, row = _topStart - 1; row < _topEnd; i++, row++)
            {
                var line = row * layerWidth;
                for (int j = 0, column = _leftStart - 1; column < _leftEnd; j++, column++)
                {
                    _data[i, j] = layerData[line + column]; 
                }
            }
        }
    }
}