using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Project.Scripts.MVC.GameField.Data.Level
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

            var layer = (JObject) jsonObject[JSONTokens.Layers][levelID];
            ReadLayerProperties(layer);
            ReadLayerData(layer);

            return new LevelData(_verticalCount, _horizontalCount, _data);
        }

        private void ReadLayerProperties(JObject layer)
        {
            var properties = layer[JSONTokens.Properties].Children();
            _leftStart = GetPropertyValue(properties, JSONTokens.KeyLeftStart);
            _leftEnd = GetPropertyValue(properties, JSONTokens.KeyLeftEnd);
            _topStart = GetPropertyValue(properties, JSONTokens.KeyTopStart);
            _topEnd = GetPropertyValue(properties, JSONTokens.KeyTopEnd);
            _verticalCount = _topEnd - _topStart + 1;
            _horizontalCount = _leftEnd - _leftStart + 1;
        }
        
        private int GetPropertyValue(IEnumerable<JToken> properties, string key)
        {
            return (int)properties.First(t => (string) t[JSONTokens.PropertyName] == key)[JSONTokens.PropertyValue];
        }

        private void ReadLayerData(JObject layer)
        {
            var layerData = layer[JSONTokens.LayerData].Select(d => (int)d).ToArray();
            var layerWidth = (int) layer[JSONTokens.LayerWidth];
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