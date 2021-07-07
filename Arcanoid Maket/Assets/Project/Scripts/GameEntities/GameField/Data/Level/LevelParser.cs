using System.Linq;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Project.Scripts.GameEntities.GameField.Data.Level
{
    public class LevelParser
    {
        private int _horizontalCount;
        private int _verticalCount;
        private int[,] _data;
        
        public LevelData GetLevelDataFromFile(string path)
        {
            var jsonFile = Resources.Load<TextAsset>(path);
            var level = JObject.Parse(jsonFile.text);
            ReadFieldSize(level);
            ReadLayerData(level);

            return new LevelData(_verticalCount, _horizontalCount, _data);
        }

        private void ReadFieldSize(JObject level)
        {
            _verticalCount = (int) level[JsonTokens.LevelHeight];
            _horizontalCount = (int) level[JsonTokens.LevelWidth];
        }

        private void ReadLayerData(JObject level)
        {
            var levelLayer = (JObject) level[JsonTokens.Layers][JsonTokens.LevelLayerID];
            var layerData = levelLayer[JsonTokens.LayerData].Select(d => (int)d).ToArray();
            
            _data = new int[_verticalCount, _horizontalCount];

            for (int i = 0; i < _verticalCount; i++)
            {
                var line = i * _horizontalCount;
                for (int j = 0; j < _horizontalCount; j++)
                {
                    _data[i, j] = layerData[line + j]; 
                }
            }
        }
    }
}