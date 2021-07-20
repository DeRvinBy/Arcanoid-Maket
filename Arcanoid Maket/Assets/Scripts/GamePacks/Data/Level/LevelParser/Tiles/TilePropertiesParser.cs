using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace GamePacks.Data.Level.LevelParser.Tiles
{
    public class TilePropertiesParser
    {
        public Dictionary<int, TileProperties> ParseTilePropertiesMap(string text)
        {
            var map = new Dictionary<int, TileProperties>();
            map.Add(0, new TileProperties {TypeId = 0});
            var tilemap = JObject.Parse(text);
            var tiles = (JArray) tilemap[JsonTilesTokens.TilesKey];
            foreach (var tile in tiles)
            {
                var id = (int) tile[JsonTilesTokens.TileId] + 1;
                var properties = (JArray) tile[JsonTilesTokens.TileProperties];
                var tileProperties = ReadTileProperties(properties);
                map.Add(id, tileProperties);
            }

            return map;
        }

        private TileProperties ReadTileProperties(JArray properties)
        {
            var result = new TileProperties();
            foreach (var property in properties)
            {
                var value = (int)property[JsonTilesTokens.PropertyValue];
                var name = (string) property[JsonTilesTokens.PropertyName];
                switch (name)
                {
                    case JsonTilesTokens.TypePropertyName:
                        result.TypeId = value;
                        break;
                    case JsonTilesTokens.SpritePropertyName:
                        result.SpriteId = value;
                        break;
                    case JsonTilesTokens.BonusPropertyName:
                        result.BonusId = value;
                        break;
                }
            }

            return result;
        }
    }
}